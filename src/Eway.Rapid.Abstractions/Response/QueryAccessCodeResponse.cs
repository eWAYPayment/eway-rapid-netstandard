using System.Collections.Generic;
using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    public class QueryAccessCodeResponse : BaseResponse
    {
        public QueryAccessCodeResponse()
        {
            Verification = new VerificationResult();
            Options = new List<Option>();
            BeagleVerification = new BeagleVerifyResult();
        }

        public string AccessCode { get; set; }
        public string AuthorisationCode { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceReference { get; set; }
        public int? TotalAmount { get; set; }
        public int? TransactionID { get; set; }
        public bool? TransactionStatus { get; set; }
        public long? TokenCustomerID { get; set; }
        public decimal? BeagleScore { get; set; }
        public List<Option> Options { get; set; }
        public VerificationResult Verification { get; set; }
        public BeagleVerifyResult BeagleVerification { get; set; }
        public ResponsePaymentInstrument PaymentInstrument { get; set; }
        public DirectTokenCustomer Customer { get; set; }
    }
}
