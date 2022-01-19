using System.Text.Json.Serialization;

namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// Credit Card Details for PCI compliant customers. When method is &#39;scheduled&#39; then either Credit Card or Bank Account Details must be provided but not both.
    /// </summary>
    public class RequestCardDetails
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

        /// <summary>
        /// Gets or Sets CVN
        /// </summary>
        public string CVN { get; set; }

    }
}
