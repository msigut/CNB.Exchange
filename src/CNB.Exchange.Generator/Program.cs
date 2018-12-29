using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CNB.Exchange.Generator
{
	class Program
	{
		static async Task Main(string[] args)
		{
			#region DI

			var services = new ServiceCollection();
			services.AddHttpClient();
			services.AddScoped<CnbClient>();
			var provider = services.BuildServiceProvider();

			#endregion

			var enumCode = new StringBuilder();
			var nameCode = new StringBuilder();

			#region Generate

			var cnb = provider.GetRequiredService<CnbClient>();
			var all = await cnb.ExchangeRateAll();

			foreach (var c in all)
			{
				var line = $"{c.Country}, {c.CurrencyName}: {c.Amount}x";

				var tab = "\t\t";
				// Currency - enum
				enumCode.AppendLine($"{tab}/// <summary>");
				enumCode.AppendLine($"{tab}/// {line}");
				enumCode.AppendLine($"{tab}/// </summary>");
				enumCode.AppendLine($"{tab}{c.Code},");

				tab = "\t\t\t\t";
				// Currency - name
				nameCode.AppendLine($"{tab}/// <summary>");
				nameCode.AppendLine($"{tab}/// {line}");
				nameCode.AppendLine($"{tab}/// </summary>");
				nameCode.AppendLine($"{tab}case CurrencyCode.{c.Code}:");
				nameCode.AppendLine($"{tab}\treturn \"{c.Country}; {c.CurrencyName}\";");
				nameCode.AppendLine();
			}

			#endregion

			#region C# code gragments

			File.WriteAllText(@"..\..\..\..\CNB.Exchange\CurrencyCode.cs", @"using System;

namespace CNB.Exchange
{	
	public enum CurrencyCode
	{
"
+ enumCode.ToString() +
@"	}
}");

			File.WriteAllText(@"..\..\..\..\CNB.Exchange\CurrencyCodeName.cs", @"using System;

namespace CNB.Exchange
{	
	public static class CurrencyCodeExtensions
	{
		public static string GetName(this CurrencyCode code)
		{
			switch (code)
			{
"
+ nameCode.ToString() +
@"
				default:
					throw new ArgumentException($""Unknown currency code: '{code}'."");
			}
		}
	}
}");

			#endregion
		}
	}
}
