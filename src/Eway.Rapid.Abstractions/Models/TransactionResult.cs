using System.Collections.Generic;
using Eway.Rapid.Abstractions.Response;

namespace Eway.Rapid.Abstractions.Models
{
    public class TransactionResult
    {
        public TransactionResult()
        {
            Verification = new VerificationResult();
            BeagleVerification = new BeagleVerifyResult();
            Options = new List<Option>();
            ShippingAddress = new ShippingAddress();
            Customer = new Customer();
            Items = new List<LineItem>();
        }

        public string TransactionDateTime { get; set; }
        public string FraudAction { get; set; }
        public bool? TransactionCaptured { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public string CurrencyCode { get; set; }
        public PaymentSource Source { get; set; }
        public int? MaxRefund { get; set; }
        public string OriginalTransactionId { get; set; }
        public Customer Customer { get; set; }
        public string AuthorisationCode { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceReference { get; set; }
        public string InvoiceDescription { get; set; }
        public int? TotalAmount { get; set; }
        public int? TransactionID { get; set; }
        public bool? TransactionStatus { get; set; }
        public long? TokenCustomerID { get; set; }
        public decimal? BeagleScore { get; set; }
        public List<Option> Options { get; set; }
        public VerificationResult Verification { get; set; }
        public BeagleVerifyResult BeagleVerification { get; set; }
        public string CustomerNote { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public List<LineItem> Items { get; set; }
        public ResponsePaymentInstrument PaymentInstrument { get; set; }
    }
}
