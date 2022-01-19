using System.Text.Json.Serialization;

namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// Transaction details for transactions processed through another gateway provider
    /// </summary>
    public class ResponseExternalTransactionDetails : BaseExternalDetails
    {
        /// <summary>
        /// The amount of purchases added to this transaction
        /// </summary>
        /// <value>The amount of purchases added to this transaction</value>
        public int? PurchaseAmount { get; set; }

        /// <summary>
        /// The status of the tender transaction
        /// </summary>
        /// <value>The status of the tender transaction</value>
        public string Status { get; set; }

        /// <summary>
        /// The specific error code associated with the tender transaction
        /// </summary>
        /// <value>The specific error code associated with the tender transaction</value>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or Sets AccountType
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Sequential Transaction Audit Number
        /// </summary>
        /// <value>Sequential Transaction Audit Number</value>
        public string Stan { get; set; }

        /// <summary>
        /// The date the financial transaction occurred on. Format is DDMMYYY.
        /// </summary>
        /// <value>The date the financial transaction occurred on. Format is DDMMYYY.</value>
        public string BankDate { get; set; }

        /// <summary>
        /// The time the financial transaction occurred on. Format is HHMMSS.
        /// </summary>
        /// <value>The time the financial transaction occurred on. Format is HHMMSS.</value>
        public string BankTime { get; set; }

        /// <summary>
        /// The customer receipt formatted to be printed. This can be sent to a printer or receipt printer for printing.
        /// </summary>
        /// <value>The customer receipt formatted to be printed. This can be sent to a printer or receipt printer for printing.</value>
        public string CustomerReceipt { get; set; }

        /// <summary>
        /// The merchant receipt formatted to be printed. This can be sent to a printer or receipt printer for printing.
        /// </summary>
        /// <value>The merchant receipt formatted to be printed. This can be sent to a printer or receipt printer for printing.</value>
        public string MerchantReceipt { get; set; }

        /// <summary>
        /// The Primary Account Number (PAN) for the card that was used in this refund. The PAN is masked and will only include the last 4 digits.
        /// </summary>
        /// <value>The Primary Account Number (PAN) for the card that was used in this refund. The PAN is masked and will only include the last 4 digits.</value>
        public string MaskedPan { get; set; }

        /// <summary>
        /// Gets or Sets CardType
        /// </summary>
        public CardType CardType { get; set; }

        /// <summary>
        /// The direct code returned by the bank for this tender
        /// </summary>
        /// <value>The direct code returned by the bank for this tender</value>
        public string HostResponseCode { get; set; }

        /// <summary>
        /// The direct text response returned by the bank for this tender
        /// </summary>
        /// <value>The direct text response returned by the bank for this tender</value>
        public string HostResponseText { get; set; }

        /// <summary>
        /// The MID for the merchant associated with the tender
        /// </summary>
        /// <value>The MID for the merchant associated with the tender</value>
        public string MerchantId { get; set; }

    }
}
