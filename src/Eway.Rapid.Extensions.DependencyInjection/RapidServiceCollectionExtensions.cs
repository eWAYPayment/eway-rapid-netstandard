using System;
using Eway.Rapid;
using Eway.Rapid.Abstractions.Interfaces;
using Microsoft.Extensions.Options;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class RapidClientExtensions
    {

        private const string RAPID_CONFIGURATION_SECTION_NAME = "RapidClient";

        /// <summary>
        /// Add Rapid
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configSectionPath"></param>
        /// <returns></returns>
        public static IHttpClientBuilder AddRapidClient(this IServiceCollection services, string configSectionPath = RAPID_CONFIGURATION_SECTION_NAME)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddOptions<RapidOptions>()
                .BindConfiguration(configSectionPath)
                .ValidateDataAnnotations();


            return services.AddHttpClient<IRapidClient, RapidClient>()
                .ConfigureHttpClient((sp, client) =>
                {
                    var options = sp.GetRequiredService<IOptionsMonitor<RapidOptions>>().CurrentValue;
                    options.ConfigureHttpClient(client);
                });
        }
    }
}
