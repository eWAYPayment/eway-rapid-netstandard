using System.Collections.Generic;

namespace Eway.Rapid.Abstractions.Response
{
    public class APICredentialsResponse : BaseResponse
    {
        public APICredentialsResponse()
        {
            ResponseCodes = new List<string>();
        }

        public string Action { get; set; }
        public string CustomerId { get; set; }
        public Result Result { get; set; }
        public List<string> ResponseCodes { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public string ApiKey { get; set; }
        public string PublicApiKey { get; set; }
    }
}
