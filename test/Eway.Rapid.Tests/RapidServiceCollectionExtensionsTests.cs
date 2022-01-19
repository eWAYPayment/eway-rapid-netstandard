using System;
using System.Collections.Generic;
using System.Net.Http;
using Eway.Rapid.Abstractions.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eway.Rapid.Tests
{
    public class RapidServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddRapidClient_UseDefaultSectionPath()
        {
            //Arrange
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(new[] {
               new KeyValuePair<string, string>("RapidClient:RapidEndPoint","production"),
               new KeyValuePair<string, string>("RapidClient:ApiKey","apikey"),
               new KeyValuePair<string, string>("RapidClient:Password","password")
            }) ;
            var configuration = configurationBuilder.Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddOptions();
            services.AddRapidClient();
            var sp = services.BuildServiceProvider();

            //act
            var rapidClient = sp.GetService<IRapidClient>() as RapidClient;

            //assert
            Assert.NotNull(rapidClient);
            var httpClient = rapidClient.HttpClient;
            Assert.Equal("https://api.ewaypayments.com/", httpClient.BaseAddress?.AbsoluteUri);
            Assert.Equal("Basic YXBpa2V5OnBhc3N3b3Jk", httpClient.DefaultRequestHeaders.Authorization?.ToString());
        }
    }
}
