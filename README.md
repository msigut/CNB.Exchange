## CNB.Exchange

CNB.cz Daily Exchange Rates .NET Standard 2.0 Library (netstandard2.0). By [ÈNB](https://www.cnb.cz/cs/faq/kurzy_devizoveho_trhu.html).

Supports
- Dependency injection by **IHttpClientFactory**
- CurrencyCode in enum (Generator included)

**With Dependency injection**

More in [CNB.Exchange.Tests](/src/CNB.Exchange.Tests) project, file: [TestFixture.cs](/src/CNB.Exchange.Tests/TestFixture.cs) and [BasicTest.cs](/src/CNB.Exchange.Tests/BasicTest.cs).
```c#
// DI configuration
services.AddHttpClient();
services.AddScoped<CnbClient>();

// in constructor
_cnb = test.Services.GetRequiredService<CnbClient>();
```