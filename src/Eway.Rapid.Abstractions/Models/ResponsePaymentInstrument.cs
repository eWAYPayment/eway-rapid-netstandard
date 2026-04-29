using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    /// <summary>
    /// The details of the payment instrument used for the transaction.
    /// </summary>
    public class ResponsePaymentInstrument
    {
        /// <summary>
        /// This set of fields contains the 3D Secure verification results
        /// </summary>
        public Direct3DSecureAuth ThreeDSecureAuth { get; set; }

        /// <summary>
        /// The payment method used for the transaction
        /// </summary>
        public string PaymentType { get; set; }
    }
}
