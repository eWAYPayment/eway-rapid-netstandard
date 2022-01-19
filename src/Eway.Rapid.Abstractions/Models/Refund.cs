namespace Eway.Rapid.Abstractions.Models
{
    public class Refund : Payment
    {
        public virtual string TransactionID { get; set; }
    }
}
