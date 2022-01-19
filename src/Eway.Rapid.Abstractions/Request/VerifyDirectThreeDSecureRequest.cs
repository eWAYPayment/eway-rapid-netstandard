namespace Eway.Rapid.Abstractions.Request
{
    public class VerifyDirectThreeDSecureRequest : BaseRequest
    {
        public string AccessCode { get; set; }
    }
}
