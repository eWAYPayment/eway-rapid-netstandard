using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    public class CreateAccountResponse : BaseResponse
    {
        /// <summary>
        /// The eWAY Customer ID of the newly created account
        /// </summary>
        public int? AccountId { get; set; }
        /// <summary>
        /// Gets or Sets AccountStatus
        /// </summary>
        public string AccountStatus { get; set; }
        /// <summary>
        /// Optional message with additional information to display to a merchant regarding thier account status
        /// </summary>
        public string StatusMessage { get; set; }
        /// <summary>
        /// The Rapid Plan Id that the new merchant should use. This should be one of the Id&#39;s issued to the partner.
        /// </summary>
        public string PlanId { get; set; }
        /// <summary>
        /// A unique ID in the partners systems to be associated with the new account
        /// </summary>
        public string AccountReference { get; set; }
        public AccountBusinessDetails BusinessDetails { get; set; }
        public AccountBusinessAddress BusinessTradingAddress { get; set; }
        public AccountProductDetails ProductDetails { get; set; }
        public AccountBankAccountDetails SettlementBankAccount { get; set; }
    }
}
