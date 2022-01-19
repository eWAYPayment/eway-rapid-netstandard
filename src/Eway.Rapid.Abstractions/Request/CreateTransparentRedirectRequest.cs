using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Request
{
    public class CreateTransparentRedirectRequest : BaseRequest
    {
        public Customer Customer { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public List<LineItem> Items { get; set; }
        public List<Option> Options { get; set; }
        public Payment Payment { get; set; }
        public virtual string RedirectUrl { get; set; }
        public virtual string CancelUrl { get; set; }
        public virtual string CheckoutUrl { get; set; }
        public string CustomerIP { get; set; }
        public string DeviceID { get; set; }
        public string PartnerID { get; set; }
        public string TrackingID { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool CheckoutPayment { get; set; }

        public Method Method
        {
            get
            {
                if (Capture)
                {//Authorise + Capture
                    return SaveCustomer ? Method.TokenPayment : Method.ProcessPayment;
                }
                else
                {//Authorise only
                    return SaveCustomer ? throw new NotSupportedException("Rapid doesn't support save customer for Authorise yet.") : Method.Authorise;
                }
            }
        }
        [JsonIgnore]
        public bool SaveCustomer { get; set; }

        [JsonIgnore]
        public bool Capture { get; set; }
    }
}
