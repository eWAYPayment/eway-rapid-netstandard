namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// The Bank Account details that were used for for PCI compliant customer. The Account number is masked and will only contain the last 4 digits.
    /// </summary>
    public class AccountBankAccountDetails
    {
        /// <summary>
        /// The bank account name for a PCI compliant customer
        /// </summary>
        public string BankAccountName { get; set; }

        /// <summary>
        /// The bank account BSB for a PCI compliant customer
        /// </summary>
        public string BankAccountBSB { get; set; }

        /// <summary>
        /// The bank account Number for a PCI compliant customer. The Account number is masked and will only contain the last 4 digits.
        /// </summary>
        public string BankAccountNumber { get; set; }
    }
}
