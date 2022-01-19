using System.Text.Json.Serialization;
using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    /// <summary>
    /// Defines the instrument that can provide/document a source of funds for a past or future transaction. Only one of the top level properties (e.g. cardDetails) must be supplied. Likewise, the API will only echo back supplied properties. Others will be omitted.
    /// </summary>
    public class ResponsePaymentInstrument
    {
        /// <summary>
        /// Gets or Sets CardDetails
        /// </summary>
        public ResponseCardDetails CardDetails { get; set; }

        /// <summary>
        /// Gets or Sets ExternalTransactionDetails
        /// </summary>
        public ResponseExternalTransactionDetails ExternalTransactionDetails { get; set; }

        /// <summary>
        /// Gets or Sets BankAccountDetails
        /// </summary>
        public ResponseBankAccountDetails BankAccountDetails { get; set; }

        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        public Metadata Metadata { get; set; }

    }
}
