using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Request
{
    public class CaptureAuthorisationRequest : BaseRequest
    {
        public Payment Payment { get; set; }
        public int TransactionID { get; set; }
    }
}
