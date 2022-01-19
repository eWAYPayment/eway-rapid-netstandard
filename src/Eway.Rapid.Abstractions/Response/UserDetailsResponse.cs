namespace Eway.Rapid.Abstractions.Response
{
    public class UserDetailsResponse : BaseResponse
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ApiKey { get; set; }
        public string PublicApiKey { get; set; }
        public string ClientPublicKey { get; set; }
        public bool IsApiPasswordSet { get; set; }
    }
}
