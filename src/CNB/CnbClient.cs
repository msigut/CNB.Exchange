using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace CNB
{
	public class CnbClient
	{
		/// <summary>
		/// CNB URL for Exchange rates
		/// </summary>
		public const string URL_EXCHANGE = "https://www.cnb.cz/cs/financni_trhy/devizovy_trh/kurzy_devizoveho_trhu/denni_kurz.txt";

		/// <summary>
		/// CNB URL for Bank codes
		/// </summary>
		public const string URL_BANK_CODES = "https://www.cnb.cz/cs/platebni-styk/.galleries/ucty_kody_bank/download/kody_bank_CR.csv";

		#region DI

		private readonly IHttpClientFactory _clientFactory;

		public CnbClient(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
		}

		#endregion

		/// <summary>
		/// get exchange rate by currency code
		/// </summary>
		public async Task<decimal> ExchangeRateCode(CurrencyCode code, DateTime? date = null)
		{
			var all = await ExchangeRateAll(date);

			var item = all.FirstOrDefault(x => x.CurrencyCode == code);
			if (item == null)
				throw new ArgumentException($"Cannot find: '{code}'.");

			return item.Rate;
		}

		/// <summary>
		/// get all exchange rates for date
		/// </summary>
		public async Task<IReadOnlyCollection<ExchangeRate>> ExchangeRateAll(DateTime? date = null)
		{
			var client = _clientFactory.CreateClient("cnb");

			var url = $"{URL_EXCHANGE}?date={(date ?? DateTime.Today).ToString("dd.MM.yyyy")}";
			var content = await client.GetStringAsync(url);

			// remove first 1 line ('28.12.2018 #249')
			var lines = content.Split(Environment.NewLine.ToCharArray()).Skip(1).ToArray();
			var cleaned = string.Join(Environment.NewLine, lines);

			ExchangeRate[] result = null;
			using (var reader = new StringReader(cleaned))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Configuration.Delimiter = "|";
				csv.Configuration.RegisterClassMap<ExchangeRateMapper>();

				result = csv.GetRecords<ExchangeRate>().ToArray();

				// parse CurrencyCode
				foreach (var item in result)
				{
					if (Enum.TryParse<CurrencyCode>(item.Code, out var temp))
						item.CurrencyCode = temp;
				}
			}
			return result;
		}

		/// <summary>
		/// get all bank codes
		/// </summary>
		public async Task<IReadOnlyCollection<BankCode>> BankCodeAll()
		{
			var client = _clientFactory.CreateClient("cnb");

			using (var stream = await client.GetStreamAsync($"{URL_BANK_CODES}"))
			using (var reader = new StreamReader(stream))
			using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true }))
			{
				csv.Configuration.Delimiter = ";";
				csv.Configuration.RegisterClassMap<BankCodeMapper>();

				return csv.GetRecords<BankCode>().ToArray();
			}
		}
	}
}
