namespace Eway.Rapid.Abstractions.Response
{
    public class CaptureAuthorisationResponse : BaseResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public int TransactionID { get; set; }
        public bool TransactionStatus { get; set; }
    }
}
