using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    public class RefundResponse : BaseResponse
    {
        public RefundResponse()
        {
            Customer = new DirectTokenCustomer();
            Refund = new Refund();
        }

        public string AuthorisationCode { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public int? TransactionID { get; set; }
        public bool? TransactionStatus { get; set; }
        public VerificationResult Verification { get; set; }
        public DirectTokenCustomer Customer { get; set; }
        public Refund Refund { get; set; }
    }
}
