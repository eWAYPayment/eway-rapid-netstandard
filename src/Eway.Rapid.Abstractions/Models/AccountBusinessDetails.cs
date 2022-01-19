namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// Business details for an account
    /// </summary>
    public class AccountBusinessDetails
    {
        /// <summary>
        /// Firstname of the owner or director of the business
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Lastname (surname) of the owner or director of the business
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The company name.
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// The website the company will be selling products from
        /// </summary>
        public string CompanyWebsite { get; set; }
        /// <summary>
        /// Customer email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Customer landline phone number
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// The eleven digit  Australian Business Nnmber registered to the company
        /// </summary>
        public string Abn { get; set; }
        /// <summary>
        /// The business industry. Must be one of the supplied values that the Partner is authorised to onboard a mercahnt with.
        /// </summary>
        public string Industry { get; set; }
    }
}
