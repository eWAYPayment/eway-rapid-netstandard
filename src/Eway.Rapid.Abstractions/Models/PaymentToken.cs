namespace Eway.Rapid.Abstractions.Models
{
    public class PaymentToken
    {
        public string ClientId { get; set; }
        public PaymentTokenType Type { get; set; }
    }
}
