using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Response
{
    public class CustomerResponse : BaseResponse
    {
        public DirectTokenCustomer Customer { get; set; }
    }
}
