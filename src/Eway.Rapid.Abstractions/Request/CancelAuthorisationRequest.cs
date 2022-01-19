namespace Eway.Rapid.Abstractions.Request
{
    public class CancelAuthorisationRequest : BaseRequest
    {
        public int TransactionID { get; set; }
    }
}
