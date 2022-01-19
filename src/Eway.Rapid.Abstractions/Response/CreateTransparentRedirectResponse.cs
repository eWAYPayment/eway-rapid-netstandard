using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    public class CreateTransparentRedirectResponse : BaseResponse
    {
        public CreateTransparentRedirectResponse()
        {
            Customer = new TokenCustomer();
            Payment = new Payment();
        }

        public string AccessCode { get; set; }
        public TokenCustomer Customer { get; set; }
        public Payment Payment { get; set; }
        public string FormActionURL { get; set; }
        public string CompleteCheckoutURL { get; set; }
        public string AmexECEncryptedData { get; set; }
    }
}
