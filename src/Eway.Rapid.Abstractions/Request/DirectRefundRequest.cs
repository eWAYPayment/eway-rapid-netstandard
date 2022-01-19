using System.Collections.Generic;
using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Request
{
    public class DirectRefundRequest : BaseRequest
    {
        public Refund Refund { get; set; }
        public DirectTokenCustomer Customer { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public List<LineItem> Items { get; set; }
        public List<Option> Options { get; set; }
        public string CustomerIP { get; set; }
        public string DeviceID { get; set; }
        public string PartnerID { get; set; }
    }
}
