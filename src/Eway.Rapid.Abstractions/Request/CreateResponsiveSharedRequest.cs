using System.ComponentModel;
using Eway.Rapid.Abstractions.Models;

namespace Eway.Rapid.Abstractions.Request
{
    public class CreateResponsiveSharedRequest : CreateTransparentRedirectRequest
    {
        public CreateResponsiveSharedRequest()
        {
            CustomerReadOnly = null;
            VerifyCustomerPhone = null;
            VerifyCustomerEmail = null;
        }

        public bool? CustomerReadOnly { get; set; }
        public bool? VerifyCustomerPhone { get; set; }
        public bool? VerifyCustomerEmail { get; set; }
        public new string CancelUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string LogoUrl { get; set; }
        public string FooterText { get; set; }
        public string HeaderText { get; set; }
        public string Language { get; set; }
        public AllowedCards AllowedCards { get; set; }
        public CustomView? CustomView { get; set; }
    }
}
