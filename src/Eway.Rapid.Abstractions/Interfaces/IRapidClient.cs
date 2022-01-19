using System.Threading;
using System.Threading.Tasks;
using Eway.Rapid.Abstractions.Request;
using Eway.Rapid.Abstractions.Response;

namespace Eway.Rapid.Abstractions.Interfaces
{
    public interface IRapidClient
    {
       
        Task<DirectPaymentResponse> CreateTransaction(DirectPaymentRequest request, CancellationToken cancellationToken = default);

        Task<CreateTransparentRedirectResponse> CreateTransaction(CreateTransparentRedirectRequest request, CancellationToken cancellationToken = default);
       
        Task<CreateResponsiveSharedResponse> CreateTransaction(CreateResponsiveSharedRequest request, CancellationToken cancellationToken = default);

        Task<CancelAuthorisationResponse> CancelAuthorisation(CancelAuthorisationRequest request, CancellationToken cancellationToken = default);

        Task<CaptureAuthorisationResponse> CaptureAuthorisation(CaptureAuthorisationRequest request, CancellationToken cancellationToken = default);

        Task<RefundResponse> Refund(string transactionId, DirectRefundRequest request, CancellationToken cancellationToken = default);

        Task<EnrolDirectThreeDSecureResponse> EnrolDirectThreeDSecure(EnrolDirectThreeDSecureRequest request, CancellationToken cancellationToken = default);

        Task<VerifyDirectThreeDSecureResponse> VerifyDirectThreeDSecure(VerifyDirectThreeDSecureRequest request, CancellationToken cancellationToken = default);

        Task<QueryAccessCodeResponse> QueryAccessCode(string accessCode, CancellationToken cancellationToken = default);

        Task<QueryTransactionResponse> QueryTransactionByTransactionId(string transactionId, CancellationToken cancellationToken = default);

        Task<QueryTransactionResponse> QueryTransactionByInvoiceNumber(string invoiceNumber, CancellationToken cancellationToken = default);

        Task<QueryTransactionResponse> QueryTransactionByInvoiceRef(string invoiceRef, CancellationToken cancellationToken = default);

        Task<CustomerResponse> CreateCustomer(CustomerRequest request, CancellationToken cancellationToken = default);

        Task<CustomerResponse> UpdateCustomer(CustomerRequest request, CancellationToken cancellationToken = default);

        Task<QueryCustomerResponse> QueryCustomer(string tokenCustomerId, CancellationToken cancellationToken = default);

        Task<CodeLookupResponse> APICodeLookup(CodeLookupRequest request, CancellationToken cancellationToken = default);
    }
}
