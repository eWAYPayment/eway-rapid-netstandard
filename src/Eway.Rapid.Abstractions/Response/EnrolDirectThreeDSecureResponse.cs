namespace Eway.Rapid.Abstractions.Response
{
    public class EnrolDirectThreeDSecureResponse : BaseResponse
    {
        /// <summary>
        /// The default 3ds page if don't want to use SDK in checkout page directly.
        /// </summary>
        public string Default3dsUrl { get; set; }
        public string AccessCode { get; set; }
    }
}
