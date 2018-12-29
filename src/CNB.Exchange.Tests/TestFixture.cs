using System;
using Microsoft.Extensions.DependencyInjection;

namespace CNB.Exchange.Tests
{
	public class TestFixture : IDisposable
	{
		/// <summary>
		/// DI
		/// </summary>
		public IServiceProvider Services { get; private set; }

		/// <summary>
		/// initialize
		/// </summary>
		public TestFixture()
		{
			// DI
			var services = new ServiceCollection();
			services.AddHttpClient();
			services.AddScoped<CnbClient>();
			Services = services.BuildServiceProvider();
		}

		/// <summary>
		/// clean up
		/// </summary>
		public void Dispose()
		{
		}
	}
}
