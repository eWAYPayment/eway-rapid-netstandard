using System.Text.Json.Serialization;

namespace Eway.Rapid.Abstractions.Response
{
    /// <summary>
    /// The Bank Account details that were used for for PCI compliant customer. The Account number is masked and will only contain the last 4 digits.
    /// </summary>
    public class ResponseBankAccountDetails
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
        /// The bank account Number for a PCI compliant customer. The Account number is masked and will only contain the last 4 digits.
        /// </summary>
        /// <value>The bank account Number for a PCI compliant customer. The Account number is masked and will only contain the last 4 digits.</value>
        public string BankAccountNumber { get; set; }

    }
}
