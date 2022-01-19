using System.Text.Json.Serialization;

namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// Bank Account details for PCI compliant customers. When method is &#39;scheduled&#39; then either Bank Account or Credit Card details must be provided but not both.
    /// </summary>
    public class RequestBankAccountDetails
    {
        /// <summary>
        /// The bank account name for a PCI compliant customer
        /// </summary>
        /// <value>The bank account name for a PCI compliant customer</value>
        public string BankAccountName { get; set; }

        /// <summary>
        /// The bank account BSB for a PCI compliant customer
        /// </summary>
        /// <value>The bank account BSB for a PCI compliant customer</value>
        public string BankAccountBSB { get; set; }

        /// <summary>
        /// The bank account Number for a PCI compliant customer
        /// </summary>
        /// <value>The bank account Number for a PCI compliant customer</value>
        public string BankAccountNumber { get; set; }

    }
}
