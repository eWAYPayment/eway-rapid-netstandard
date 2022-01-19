namespace Eway.Rapid.Abstractions.Models
{
    public class Payment
    {
        /// <summary>The total amount to charge the card holder in this transaction</summary>        
        public virtual int TotalAmount { get; set; }

        /// <summary>The merchant's invoice number</summary>
        public virtual string InvoiceNumber { get; set; }

        /// <summary>merchants invoice description</summary>
        public virtual string InvoiceDescription { get; set; }

        /// <summary>The merchant's invoice reference</summary>
        public virtual string InvoiceReference { get; set; }

        /// <summary>The merchant's currency</summary>
        public virtual string CurrencyCode { get; set; }
    }
}
