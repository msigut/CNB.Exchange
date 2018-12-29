using CsvHelper.Configuration;

namespace CNB.Exchange
{
	/// <summary>
	/// CNB exchange rate
	/// </summary>
	public class ExchangeRate
	{
		/// <summary>
		/// country
		/// </summary>
		public string Country { get; set; }
		/// <summary>
		/// currency name
		/// </summary>
		public string CurrencyName { get; set; }
		/// <summary>
		/// currency amount
		/// </summary>
		public int Amount { get; set; }
		/// <summary>
		/// currency code (string)
		/// </summary>
		public string Code { get; set; }
		/// <summary>
		/// exchange rate
		/// </summary>
		public decimal Rate { get; set; }

		/// <summary>
		/// currency code
		/// </summary>
		public CurrencyCode? CurrencyCode { get; set; }
	}

	/// <remarks>
	/// CSV mapping
	/// </remarks>
	internal class ExchangeRateMapper : ClassMap<ExchangeRate>
	{
		public ExchangeRateMapper()
		{
			var i = 0;
			Map(m => m.Country).Index(i++);
			Map(m => m.CurrencyName).Index(i++);
			Map(m => m.Amount).Index(i++);
			Map(m => m.Code).Index(i++);
			Map(m => m.Rate).Index(i++);
		}
	}
}
