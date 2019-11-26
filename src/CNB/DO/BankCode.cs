using CsvHelper.Configuration;

namespace CNB
{
	/// <summary>
	/// CNB bank code
	/// </summary>
	public class BankCode
	{
		/// <summary>
		/// Code [Kód platebního styku]
		/// </summary>
		public string Code { get; set; }
		/// <summary>
		/// Name [Poskytovatel platebních služeb]
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// BIC (SWIFT)
		/// </summary>
		public string BIC { get; set; }
		/// <summary>
		/// CERTIS [Systém CERTIS]
		/// </summary>
		public string CERTIS { get; set; }
	}

	/// <remarks>
	/// CSV mapping
	/// </remarks>
	internal class BankCodeMapper : ClassMap<BankCode>
	{
		public BankCodeMapper()
		{
			var i = 0;
			Map(m => m.Code).Index(i++);
			Map(m => m.Name).Index(i++);
			Map(m => m.BIC).Index(i++);
			Map(m => m.CERTIS).Index(i++);
		}
	}
}
