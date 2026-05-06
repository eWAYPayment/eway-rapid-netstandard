using System;

namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// Represents a payment instrument request containing details for various supported payment methods.
    /// </summary>
    public class RequestPaymentInstrument
    {
        /// <summary>
        /// Gets or Sets PaymentType
        /// </summary>
        public PaymentType PaymentType { get; set; }

        [Obsolete("This property is deprecated.")]
        public RequestCardDetails CardDetails { get; set; }

        /// <summary>
        /// WalletDetails details.
        /// </summary>
        public RequestWalletDetails WalletDetails { get; set; }

        /// <summary>
        /// ThreeDSecureAuth details
        /// </summary>
        public Direct3DSecureAuth ThreeDSecureAuth { get; set; }

        [Obsolete("This property is deprecated.")]
        public string EncryptedCardDetails { get; set; }

        [Obsolete("This property is deprecated.")]
        public BaseExternalDetails ExternalTransactionDetails { get; set; }

        [Obsolete("This property is deprecated.")]
        public RequestBankAccountDetails BankAccountDetails { get; set; }

        [Obsolete("This property is deprecated.")]
        public Metadata Metadata { get; set; }

    }
}
