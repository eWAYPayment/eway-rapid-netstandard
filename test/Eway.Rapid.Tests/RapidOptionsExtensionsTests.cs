using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace Eway.Rapid.Tests
{
    public class RapidOptionsExtensionsTests
    {
        [Fact]
        public void ConfigureHttpClient_Throw_NullParameter()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => default(RapidOptions).ConfigureHttpClient(new HttpClient()));
            Assert.Equal("options", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(
                () => new RapidOptions().ConfigureHttpClient(null));
            Assert.Equal("httpClient", ex.ParamName);
        }


        [Fact]
        public void ConfigureHttpClient_UpdateHttpClient()
        {
            //arrange
            var options = new RapidOptions()
            {
                ApiKey = "apikey",
                Password = "password",
                RapidEndPoint = "Production"
            };
            var httpClient = new HttpClient();

            //act
            options.ConfigureHttpClient(httpClient);

            //assert
            Assert.Equal("https://api.ewaypayments.com/", httpClient.BaseAddress?.AbsoluteUri);
            Assert.Equal("Basic YXBpa2V5OnBhc3N3b3Jk", httpClient.DefaultRequestHeaders.Authorization?.ToString());
            Assert.Matches(@"EwayNetStandardSDK/[\d\.]+", httpClient.DefaultRequestHeaders.UserAgent?.ToString());
        }

        [Theory]
        [InlineData("Production", "https://api.ewaypayments.com/")]
        [InlineData("proDuction", "https://api.ewaypayments.com/")]
        [InlineData("Sandbox", "https://api.sandbox.ewaypayments.com/")]
        [InlineData("SANDBOX", "https://api.sandbox.ewaypayments.com/")]
        [InlineData("https://localhost:5000", "https://localhost:5000/")]
        public void CreateUri_Tests(string endpoint, string expectedUri)
        {
            //arrange
            var options = new RapidOptions
            {
                RapidEndPoint = endpoint
            };

            //act
            var uri = options.CreateUri();

            //assert
            var actual = uri.AbsoluteUri;
            Assert.Equal(expectedUri, actual);
        }

        [Theory]
        [MemberData(nameof(GetRapidOptionsWithNullEndpoint))]
        public void CreateUri_Throw_NullEndpoint(RapidOptions rapidOptions)
        {
            var ex = Assert.Throws<ArgumentException>(() => rapidOptions.CreateUri());
            Assert.Equal("RapidEndPoint can not be empty.", ex.Message);
        }

        public static IEnumerable<object[]> GetRapidOptionsWithNullEndpoint()
        {
            return new List<object[]>
            {
                new object[]{ null },
                new object[]{ new RapidOptions() },
                new object[]{ new RapidOptions{ RapidEndPoint = string.Empty} }
            };
        }
    }
}
