using Eway.Rapid.Abstractions.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eway.Rapid.IntegrationTests
{
    public class RapidClientFixture 
    {
        public RapidClientFixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddRapidClient();
            var sp = services.BuildServiceProvider();

            RapidClient = sp.GetRequiredService<IRapidClient>();
        }

        public IRapidClient RapidClient { get; private set; }
    }
}
