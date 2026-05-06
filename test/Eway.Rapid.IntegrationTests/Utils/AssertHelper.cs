using Eway.Rapid.Abstractions.Models;
using Xunit;

namespace Eway.Rapid.IntegrationTests.Utils
{
    public class AssertHelper
    {
        internal static void Assert_VerifyCustomerAddress(Customer requestCustomer, Customer responseCustomer)
        {
            Assert.Equal(responseCustomer.State, requestCustomer.State);
            Assert.Equal(responseCustomer.City, requestCustomer.City);
            Assert.Equal(responseCustomer.Country, requestCustomer.Country);
            Assert.Equal(responseCustomer.PostalCode, requestCustomer.PostalCode);
            Assert.Equal(responseCustomer.Street1, requestCustomer.Street1);
            Assert.Equal(responseCustomer.Street2, requestCustomer.Street2);
        }

        internal static void Assert_ThreeDSecureAuth(Direct3DSecureAuth request3DSecureAuth, Direct3DSecureAuth response3DSecureAuth)
        {
            Assert.Equal(response3DSecureAuth.Cryptogram, request3DSecureAuth.Cryptogram);
            Assert.Equal(response3DSecureAuth.ECI, request3DSecureAuth.ECI);
            Assert.Equal(response3DSecureAuth.XID, request3DSecureAuth.XID);
            Assert.Equal(response3DSecureAuth.AuthStatus, request3DSecureAuth.AuthStatus);
            Assert.Equal(response3DSecureAuth.dsTransactionId, request3DSecureAuth.dsTransactionId);
            Assert.Equal(response3DSecureAuth.Version, request3DSecureAuth.Version);
        }

        internal static void Assert_VerifyCustomerAllFields(Customer requestCustomer, Customer responseCustomer)
        {
            Assert.Equal(responseCustomer.Comments, requestCustomer.Comments);
            Assert.Equal(responseCustomer.CompanyName, requestCustomer.CompanyName);
            Assert.Equal(responseCustomer.Fax, requestCustomer.Fax);
            Assert.Equal(responseCustomer.FirstName, requestCustomer.FirstName);
            Assert.Equal(responseCustomer.LastName, requestCustomer.LastName);
            Assert.Equal(responseCustomer.JobDescription, requestCustomer.JobDescription);
            Assert.Equal(responseCustomer.Mobile, requestCustomer.Mobile);
            Assert.Equal(responseCustomer.Phone, requestCustomer.Phone);
            Assert.Equal(responseCustomer.Reference, requestCustomer.Reference);
            Assert.Equal(responseCustomer.Title, requestCustomer.Title);
            Assert.Equal(responseCustomer.Url, requestCustomer.Url);
        }

        internal static void Assert_VerifyCustoemrCardDetails(DirectTokenCustomer requestCustomer, DirectTokenCustomer responseCustomer)
        {
            if (!string.IsNullOrWhiteSpace(responseCustomer.CardDetails.ExpiryMonth) &&
                !string.IsNullOrWhiteSpace(requestCustomer.CardDetails.ExpiryMonth))
                Assert.Equal(responseCustomer.CardDetails.ExpiryMonth, requestCustomer.CardDetails.ExpiryMonth);

            if (!string.IsNullOrWhiteSpace(responseCustomer.CardDetails.ExpiryYear) &&
                !string.IsNullOrWhiteSpace(requestCustomer.CardDetails.ExpiryYear))
                Assert.Equal(responseCustomer.CardDetails.ExpiryYear, requestCustomer.CardDetails.ExpiryYear);

            if (!string.IsNullOrWhiteSpace(responseCustomer.CardDetails.IssueNumber) &&
                !string.IsNullOrWhiteSpace(requestCustomer.CardDetails.IssueNumber))
                Assert.Equal(responseCustomer.CardDetails.IssueNumber, requestCustomer.CardDetails.IssueNumber);

            if (!string.IsNullOrWhiteSpace(responseCustomer.CardDetails.Name) &&
                !string.IsNullOrWhiteSpace(requestCustomer.CardDetails.Name))
                Assert.Equal(responseCustomer.CardDetails.Name, requestCustomer.CardDetails.Name);

            if (!string.IsNullOrWhiteSpace(responseCustomer.CardDetails.StartMonth) &&
                !string.IsNullOrWhiteSpace(requestCustomer.CardDetails.StartMonth))
                Assert.Equal(responseCustomer.CardDetails.StartMonth, requestCustomer.CardDetails.StartMonth);

            if (!string.IsNullOrWhiteSpace(responseCustomer.CardDetails.StartYear) &&
                !string.IsNullOrWhiteSpace(requestCustomer.CardDetails.StartYear))
                Assert.Equal(responseCustomer.CardDetails.StartYear, requestCustomer.CardDetails.StartYear);
        }
    }
}
