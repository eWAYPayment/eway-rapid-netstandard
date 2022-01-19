using System.Collections.Generic;
using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Request
{
    /// <summary>
    /// This request is used to send a 3ds enroll request
    /// </summary>
    public class EnrolDirectThreeDSecureRequest : BaseRequest
    {
        public DirectTokenCustomer Customer { get; set; } = new DirectTokenCustomer();
        public ShippingAddress ShippingAddress { get; set; }
        public List<LineItem> Items { get; set; }
        public Payment Payment { get; set; }
        public string SecuredCardData { get; set; }
        public string RedirectUrl { get; set; }
        public string PartnerID { get; set; }
    }
}
