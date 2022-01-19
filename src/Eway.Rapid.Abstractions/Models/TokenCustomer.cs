namespace Eway.Rapid.Abstractions.Models
{
    public class TokenCustomer : Customer
    {
        public string CardNumber { get; set; }
        public string CardStartMonth { get; set; }
        public string CardStartYear { get; set; }
        public string CardIssueNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpiryMonth { get; set; }
        public string CardExpiryYear { get; set; }
        public bool IsActive { get; set; }
    }
}
