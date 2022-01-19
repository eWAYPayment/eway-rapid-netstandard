using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    public class VerifyDirectThreeDSecureResponse : BaseResponse
    {
        public string AccessCode { get; set; }
        public bool Enrolled { get; set; }
        public Direct3DSecureAuth ThreeDSecureAuth { get; set; }
    }
}
