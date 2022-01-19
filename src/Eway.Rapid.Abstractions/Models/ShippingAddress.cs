using System.Text.Json.Serialization;

namespace Eway.Rapid.Abstractions.Models
{

    public class ShippingAddress
    {
        /// <summary>
        /// Gets or Sets ShippingMethod
        /// </summary>
        public string ShippingMethod { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets Street1
        /// </summary>
        public string Street1 { get; set; }

        /// <summary>
        /// Gets or Sets Street2
        /// </summary>
        public string Street2 { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or Sets PostalCode
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or Sets Mobile
        /// </summary>
        public string Mobile { get; set; }

    }
}
