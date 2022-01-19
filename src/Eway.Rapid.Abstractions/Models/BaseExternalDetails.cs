using System.Text.Json.Serialization;

namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// Common elements usable in every request processed through another gateway provider
    /// </summary>    
    public class BaseExternalDetails
    {
        /// <summary>
        /// The Terminal ID (ETTD)
        /// </summary>
        /// <value>The Terminal ID (ETTD)</value>
        public string TerminalId { get; set; }

        /// <summary>
        /// Your payment reference. This can be up to 16 characters and can be any printable ASCII characters and must be unique. When the method is &#39;scheduled&#39; then this value is required it&#39;s an ID that you can use to later identify this payment in Rapid+. This ID might be a specific Invoice or Order number within your system relating to an individual payment. The PaymentReference can also be searched for using a wildcard in other methods. You might choose to provide delimited references that identify the batch or customer and payment or any other additional data that you might wish to search on later.
        /// </summary>
        /// <value>Your payment reference. This can be up to 16 characters and can be any printable ASCII characters and must be unique. When the method is &#39;scheduled&#39; then this value is required it&#39;s an ID that you can use to later identify this payment in Rapid+. This ID might be a specific Invoice or Order number within your system relating to an individual payment. The PaymentReference can also be searched for using a wildcard in other methods. You might choose to provide delimited references that identify the batch or customer and payment or any other additional data that you might wish to search on later.</value>
        public string PaymentReference { get; set; }

        /// <summary>
        /// Retrieval Reference Number
        /// </summary>
        /// <value>Retrieval Reference Number</value>
        public string Rrn { get; set; }

    }
}
