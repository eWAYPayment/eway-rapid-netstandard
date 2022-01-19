using System.ComponentModel.DataAnnotations;
using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Request
{
    public class CreateAccountRequest : BaseRequest
    {
        /// <summary>
        /// The Rapid Plan Id that the new merchant should use. This should be one of the Id&#39;s issued to the partner.
        /// </summary>
        [Required]
        public string PlanId { get; set; }
        /// <summary>
        /// A unique ID in the partners systems to be associated with the new account
        /// </summary>
        [Required]
        public string AccountReference { get; set; }
        /// <summary>
        /// Gets or Sets BusinessDetails
        /// </summary>
        [Required]
        public AccountBusinessDetails BusinessDetails { get; set; }
        /// <summary>
        /// Gets or Sets BusinessTradingAddress
        /// </summary>
        [Required]
        public AccountBusinessAddress BusinessTradingAddress { get; set; }
        /// <summary>
        /// Gets or Sets ProductDetails
        /// </summary>
        [Required]
        public AccountProductDetails ProductDetails { get; set; }
        /// <summary>
        /// Gets or Sets SettlementBankAccount
        /// </summary>
        [Required]
        public AccountBankAccountDetails SettlementBankAccount { get; set; }
    }
}
