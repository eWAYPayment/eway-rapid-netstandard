using System.Collections.Generic;
using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    public class QueryCustomerResponse : BaseResponse
    {
        public List<DirectTokenCustomer> Customers { get; set; }
    }
}
