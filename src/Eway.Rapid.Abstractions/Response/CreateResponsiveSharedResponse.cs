using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    public class CreateResponsiveSharedResponse : BaseResponse
    {
        public string SharedPaymentUrl { set; get; }
        public string AccessCode { get; set; }
        public TokenCustomer Customer { get; set; }
        public Payment Payment { get; set; }
        public string FormActionURL { get; set; }
        public string CompleteCheckoutURL { get; set; }
    }
}
