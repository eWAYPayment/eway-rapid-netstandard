using System.Collections.Generic;
using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    public class QueryTransactionResponse : BaseResponse
    {
        public List<TransactionResult> Transactions { get; set; }
        public int TotalRows { get; set; }
    }
}
