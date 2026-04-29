using System.Text.Json.Serialization;

namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// Defines the instrument that can provide/document a source of funds for a past or future transaction. Only one of the top level properties (e.g. cardDetails) must be supplied. Likewise, the API will only echo back supplied properties. Others may be omitted. When the method &#x3D; &#39;Scheduled&#39; then either &#39;Bank Account Details&#39; or &#39;Credit Card detail&#39;s must be provided (not both).
    /// </summary>
    public class RequestPaymentInstrument
    {
        /// <summary>
        /// Gets or Sets PaymentType
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// WalletDetails details.
        /// </summary>
        public RequestWalletDetails WalletDetails { get; set; }

        /// <summary>
        /// ThreeDSecureAuth details
        /// </summary>
        public Direct3DSecureAuth ThreeDSecureAuth { get; set; }

    }
}
