using System;

namespace CNB
{	
	public static class CurrencyCodeExtensions
	{
		public static string GetName(this CurrencyCode code)
		{
			switch (code)
			{
				/// <summary>
				/// Austrálie, dolar: 1x
				/// </summary>
				case CurrencyCode.AUD:
					return "Austrálie; dolar";

				/// <summary>
				/// Brazílie, real: 1x
				/// </summary>
				case CurrencyCode.BRL:
					return "Brazílie; real";

				/// <summary>
				/// Bulharsko, lev: 1x
				/// </summary>
				case CurrencyCode.BGN:
					return "Bulharsko; lev";

				/// <summary>
				/// Čína, žen-min-pi: 1x
				/// </summary>
				case CurrencyCode.CNY:
					return "Čína; žen-min-pi";

				/// <summary>
				/// Dánsko, koruna: 1x
				/// </summary>
				case CurrencyCode.DKK:
					return "Dánsko; koruna";

				/// <summary>
				/// EMU, euro: 1x
				/// </summary>
				case CurrencyCode.EUR:
					return "EMU; euro";

				/// <summary>
				/// Filipíny, peso: 100x
				/// </summary>
				case CurrencyCode.PHP:
					return "Filipíny; peso";

				/// <summary>
				/// Hongkong, dolar: 1x
				/// </summary>
				case CurrencyCode.HKD:
					return "Hongkong; dolar";

				/// <summary>
				/// Chorvatsko, kuna: 1x
				/// </summary>
				case CurrencyCode.HRK:
					return "Chorvatsko; kuna";

				/// <summary>
				/// Indie, rupie: 100x
				/// </summary>
				case CurrencyCode.INR:
					return "Indie; rupie";

				/// <summary>
				/// Indonesie, rupie: 1000x
				/// </summary>
				case CurrencyCode.IDR:
					return "Indonesie; rupie";

				/// <summary>
				/// Island, koruna: 100x
				/// </summary>
				case CurrencyCode.ISK:
					return "Island; koruna";

				/// <summary>
				/// Izrael, nový šekel: 1x
				/// </summary>
				case CurrencyCode.ILS:
					return "Izrael; nový šekel";

				/// <summary>
				/// Japonsko, jen: 100x
				/// </summary>
				case CurrencyCode.JPY:
					return "Japonsko; jen";

				/// <summary>
				/// Jižní Afrika, rand: 1x
				/// </summary>
				case CurrencyCode.ZAR:
					return "Jižní Afrika; rand";

				/// <summary>
				/// Kanada, dolar: 1x
				/// </summary>
				case CurrencyCode.CAD:
					return "Kanada; dolar";

				/// <summary>
				/// Korejská republika, won: 100x
				/// </summary>
				case CurrencyCode.KRW:
					return "Korejská republika; won";

				/// <summary>
				/// Maďarsko, forint: 100x
				/// </summary>
				case CurrencyCode.HUF:
					return "Maďarsko; forint";

				/// <summary>
				/// Malajsie, ringgit: 1x
				/// </summary>
				case CurrencyCode.MYR:
					return "Malajsie; ringgit";

				/// <summary>
				/// Mexiko, peso: 1x
				/// </summary>
				case CurrencyCode.MXN:
					return "Mexiko; peso";

				/// <summary>
				/// MMF, ZPČ: 1x
				/// </summary>
				case CurrencyCode.XDR:
					return "MMF; ZPČ";

				/// <summary>
				/// Norsko, koruna: 1x
				/// </summary>
				case CurrencyCode.NOK:
					return "Norsko; koruna";

				/// <summary>
				/// Nový Zéland, dolar: 1x
				/// </summary>
				case CurrencyCode.NZD:
					return "Nový Zéland; dolar";

				/// <summary>
				/// Polsko, zlotý: 1x
				/// </summary>
				case CurrencyCode.PLN:
					return "Polsko; zlotý";

				/// <summary>
				/// Rumunsko, leu: 1x
				/// </summary>
				case CurrencyCode.RON:
					return "Rumunsko; leu";

				/// <summary>
				/// Rusko, rubl: 100x
				/// </summary>
				case CurrencyCode.RUB:
					return "Rusko; rubl";

				/// <summary>
				/// Singapur, dolar: 1x
				/// </summary>
				case CurrencyCode.SGD:
					return "Singapur; dolar";

				/// <summary>
				/// Švédsko, koruna: 1x
				/// </summary>
				case CurrencyCode.SEK:
					return "Švédsko; koruna";

				/// <summary>
				/// Švýcarsko, frank: 1x
				/// </summary>
				case CurrencyCode.CHF:
					return "Švýcarsko; frank";

				/// <summary>
				/// Thajsko, baht: 100x
				/// </summary>
				case CurrencyCode.THB:
					return "Thajsko; baht";

				/// <summary>
				/// Turecko, lira: 1x
				/// </summary>
				case CurrencyCode.TRY:
					return "Turecko; lira";

				/// <summary>
				/// USA, dolar: 1x
				/// </summary>
				case CurrencyCode.USD:
					return "USA; dolar";

				/// <summary>
				/// Velká Británie, libra: 1x
				/// </summary>
				case CurrencyCode.GBP:
					return "Velká Británie; libra";


				default:
					throw new ArgumentException($"Unknown currency code: '{code}'.");
			}
		}
	}
}