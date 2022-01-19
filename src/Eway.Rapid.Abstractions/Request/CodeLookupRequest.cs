using System.Collections.Generic;

namespace Eway.Rapid.Abstractions.Request
{
    public class CodeLookupRequest : BaseRequest
    {
        public string Language { get; set; }
        public List<string> ErrorCodes { get; set; }
    }
}
