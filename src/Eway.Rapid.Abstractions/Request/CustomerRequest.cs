using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Request
{
    public class CustomerRequest : BaseRequest
    {
        public DirectTokenCustomer Customer { get; set; }
        /// <summary>
        /// Generic ID used by various third party Credit card wallets. For Visa Checkout values will start with "VisaCheckout:".
        /// </summary>
        public string ThirdPartyWalletID
        {
            get { return SecuredCardData; }
            set { SecuredCardData = value; }
        }
        /// <summary>
        /// ID for any third party (or internal) secure card store. VisaCheckout, Amex, or Secure Fields
        /// </summary>
        public string SecuredCardData { get; set; }
        public PaymentToken PaymentToken { get; set; }
        public string PartnerID { get; set; }
    }
}
