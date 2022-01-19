using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Request
{
    public class DirectPaymentRequest : BaseRequest
    {
        /// <summary>
        /// Customer information for the request.
        /// </summary>
        public DirectTokenCustomer Customer { get; set; }
        /// <summary>
        /// Customer's Shipping address
        /// </summary>
        public ShippingAddress ShippingAddress { get; set; }
        /// <summary>
        /// List of Line items for this transaction
        /// </summary>
        public List<LineItem> Items { get; set; }
        /// <summary>
        /// List of options set for this transaction
        /// </summary>
        public List<Option> Options { get; set; }
        /// <summary>
        /// Payment Details
        /// </summary>
        public Payment Payment { get; set; }
        public virtual string RedirectUrl { get; set; }
        /// <summary>
        /// IP of the Customer's system 
        /// </summary>
        public string CustomerIP { get; set; }
        public string DeviceID { get; set; }
        public string PartnerID { get; set; }
        public TransactionTypes TransactionType { get; set; }
        /// <summary>
        /// Generic ID used by various third party Credit card wallets. For Visa Checkout values will start with "VisaCheckout:".
        /// Now only a synonym for SecureCardStoreID as is will be used for Third party and internal card stores
        /// </summary>
        public string ThirdPartyWalletID { get; set; }
        /// <summary>
        /// ID for any third party (or internal) secure card store. VisaCheckout, Amex, or Secure Fields
        /// </summary>
        public string SecuredCardData { get; set; }
        public RequestPaymentInstrument PaymentInstrument { get; set; }
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
        public bool Capture { get; set; } = true;

    }
}
