using System.Text.Json.Serialization;

namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// Masked Credit Card Details either supplied by the customer, or decrypted/supplied from a token source.
    /// </summary>
    public class ResponseCardDetails
    {
        /// <summary>
        /// Gets or Sets Number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets ExpiryMonth
        /// </summary>
        public string ExpiryMonth { get; set; }

        /// <summary>
        /// Gets or Sets ExpiryYear
        /// </summary>
        public string ExpiryYear { get; set; }

        /// <summary>
        /// Gets or Sets StartMonth
        /// </summary>
        public string StartMonth { get; set; }

        /// <summary>
        /// Gets or Sets StartYear
        /// </summary>
        public string StartYear { get; set; }

        /// <summary>
        /// Gets or Sets IssueNumber
        /// </summary>
        public string IssueNumber { get; set; }

    }
}
