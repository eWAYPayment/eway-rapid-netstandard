namespace Eway.Rapid.Abstractions.Request
{
    public class APIPasswordChangeRequest : BaseRequest
    {
        public int? UserID { get; set; }
        public string Username { get; set; }
        public string NewApiPassword { get; set; }
    }
}
