namespace Eway.Rapid.Abstractions.Request
{
    public class APICredentialsRequest : BaseRequest
    {
        public int CustomerId { get; set; }
        public string CustomerRef { get; set; }
        public string Password { get; set; }
    }
}
