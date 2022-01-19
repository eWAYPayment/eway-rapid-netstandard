using System.Collections.Generic;
using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    public class CodeLookupResponse : BaseResponse
    {
        public string Language { get; set; }
        public List<ErrorCodeDetails> CodeDetails { get; set; }
    }
}
