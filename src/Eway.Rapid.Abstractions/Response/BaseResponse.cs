using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    public class BaseResponse
    {
        public string Errors { get; set; }
        public int? HttpStatusCode { get; set; }
        public string Location { get; set; }
    }
}
