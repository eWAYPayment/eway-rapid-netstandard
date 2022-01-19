using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace Eway.Rapid
{
    public static class RapidOptionsExtensions
    {
        public static void ConfigureHttpClient(this RapidOptions options, HttpClient httpClient)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (httpClient is null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            var version = new ProductInfoHeaderValue("EwayNetStandardSDK", Assembly.GetAssembly(typeof(RapidOptionsExtensions)).GetName().Version.ToString());
            httpClient.DefaultRequestHeaders.UserAgent.Add(version);
            httpClient.BaseAddress = options.CreateUri();
            httpClient.DefaultRequestHeaders.Authorization = options.CreateBasicAuthHeader();
        }


        public static AuthenticationHeaderValue CreateBasicAuthHeader(this RapidOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var bytes = Encoding.UTF8.GetBytes(options.ApiKey + ":" + options.Password);
            var parameter = Convert.ToBase64String(bytes);
            return new AuthenticationHeaderValue("Basic", parameter);
        }

        public static Uri CreateUri(this RapidOptions options)
        {
            if (options == null || string.IsNullOrEmpty(options.RapidEndPoint))
            {
                throw new ArgumentException("RapidEndPoint can not be empty.");
            }

            var endpoint = options.RapidEndPoint;
            string url;

            if (string.Equals(endpoint, RapidEndpoints.PRODUCTION_ALIAS, StringComparison.OrdinalIgnoreCase))
            {
                url = RapidEndpoints.PRODUCTION;
            }
            else if (string.Equals(endpoint, RapidEndpoints.SANDBOX_ALIAS, StringComparison.OrdinalIgnoreCase))
            {
                url = RapidEndpoints.SANDBOX;
            }
            else
            {
                url = endpoint;
            }
            if (!url.EndsWith("/"))
            {
                url += "/";
            }
            var uri = new Uri(url);

            return uri;
        }
    }
}
