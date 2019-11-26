using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CNB.Tests
{
	public class BasicTest: IClassFixture<TestFixture>
	{
		#region DI

		private readonly CnbClient _cnb;

		public BasicTest(TestFixture test)
		{
			_cnb = test.Services.GetRequiredService<CnbClient>();
		}

		#endregion

		[Fact]
		public async Task TestExchangeRate()
		{
			var rates = await _cnb.ExchangeRateAll();

			Assert.NotEmpty(rates);
			Assert.Contains(rates, x => !string.IsNullOrEmpty(x.Country));
			Assert.Contains(rates, x => !string.IsNullOrEmpty(x.CurrencyName));
			Assert.Contains(rates, x => x.Amount > 0);
			Assert.Contains(rates, x => !string.IsNullOrEmpty(x.Code));
			Assert.Contains(rates, x => x.CurrencyCode == CurrencyCode.EUR);
			Assert.Contains(rates, x => x.CurrencyCode == CurrencyCode.USD);
			Assert.Contains(rates, x => x.Rate > 0);
		}

		[Fact]
		public async Task TestBankCode()
		{
			var codes = await _cnb.BankCodeAll();

			Assert.NotEmpty(codes);
			Assert.All(codes, x => Assert.NotEmpty(x.Code));
			Assert.All(codes, x => Assert.NotEmpty(x.Name));
			Assert.Contains(codes, x => !string.IsNullOrEmpty(x.BIC));
			Assert.Contains(codes, x => !string.IsNullOrEmpty(x.CERTIS));
		}

		[Fact]
		public async Task TestExchangeRateCode()
		{
			Assert.True(await _cnb.ExchangeRateCode(CurrencyCode.EUR) > 20m);
			Assert.True(await _cnb.ExchangeRateCode(CurrencyCode.USD) > 20m);
		}

		[Fact]
		public async Task TestExchangeRateDate()
		{
			var rates = await _cnb.ExchangeRateAll(new DateTime(2018, 12, 24));

			Assert.NotEmpty(rates);
			Assert.True(rates.Count() > 10);
		}
	}
}
