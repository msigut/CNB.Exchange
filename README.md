## CNB.Exchange

CNB.cz Daily Exchange Rates .NET Standard 2.0 Library (netstandard2.0). By [ČNB](https://www.cnb.cz) [documentation](https://www.cnb.cz/cs/faq/kurzy_devizoveho_trhu.html). Use public [plain-text API](https://www.cnb.cz/cs/financni_trhy/devizovy_trh/kurzy_devizoveho_trhu/denni_kurz.txt).

Supports
- Dependency injection by **IHttpClientFactory**
- **[CurrencyCode](/src/CNB.Exchange/CurrencyCode.cs)** as enum (Generator project included)
- direct query for exchange-rate by **ExchangeRateCode** 

**Dependency injection**

More in [CNB.Exchange.Tests](/src/CNB.Exchange.Tests) project, file: [TestFixture.cs](/src/CNB.Exchange.Tests/TestFixture.cs) and [BasicTest.cs](/src/CNB.Exchange.Tests/BasicTest.cs).
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
```

[ExchangeRate.cs](/src/CNB.Exchange/ExchangeRate.cs) contains:
- **Country** - country name (in Czech)
- **CurrencyName** - currency name (in Czech)
- **Amount** - currency amount (example: 1, 100)
- **Code** - currency code (as string; example: EUR, USD, ...)
- **Rate** - exchange rate (as decimal; example: 25.877)
- **CurrencyCode** - code (as nullable enum; example: CurrencyCode.EUR, CurrencyCode.GBR, ...)
