## CNB.Exchange

CNB.cz .NET Standard 2.0 Library (netstandard2.0). By [ČNB](https://www.cnb.cz) 
- Daily Exchange Rates [[documentation](https://www.cnb.cz/cs/faq/kurzy_devizoveho_trhu.html). Uses public [plain-text API - CSV](https://www.cnb.cz/cs/financni_trhy/devizovy_trh/kurzy_devizoveho_trhu/denni_kurz.txt)]
- Bank codes [[plain-text API - CSV](https://www.cnb.cz/cs/platebni-styk/.galleries/ucty_kody_bank/download/kody_bank_CR.csv)]

Supports
- Dependency injection by **IHttpClientFactory**
- **[CurrencyCode](/src/CNB/CurrencyCode.cs)** as enum (Generator project included)
- direct query for exchange-rate by **ExchangeRateCode** 

**Dependency injection**

More in [CNB.Tests](/src/CNB.Tests) project, file: [TestFixture.cs](/src/CNB.Tests/TestFixture.cs) and [BasicTest.cs](/src/CNB.Tests/BasicTest.cs).
```c#
// DI configuration
services.AddHttpClient();
services.AddScoped<CnbClient>();

// in constructor
_cnb = test.Services.GetRequiredService<CnbClient>();
```

**Using**
```c#
// return decimal value of Exchange rate for EUR
await _cnb.ExchangeRateCode(CurrencyCode.EUR);

// return all Exchange rates
await _cnb.ExchangeRateAll();

// return all Bank codes
await _cnb.BankCodeAll();
```

[ExchangeRate.cs](/src/CNB/DO/ExchangeRate.cs) contains:
- **Country** - country name (in Czech)
- **CurrencyName** - currency name (in Czech)
- **Amount** - currency amount (example: 1, 100)
- **Code** - currency code (as string; example: EUR, USD, ...)
- **Rate** - exchange rate (as decimal; example: 25.877)
- **CurrencyCode** - code (as nullable enum; example: CurrencyCode.EUR, CurrencyCode.GBR, ...)

[BankCode.cs](/src/CNB/DO/BankCode.cs) contains:
- **Code** - bank code
- **Name** - bank name (in Czech)
- **BIC** - BIC (SWIFT)
- **CERTIS** - CERTIS
