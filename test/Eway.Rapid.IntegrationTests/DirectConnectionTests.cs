using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eway.Rapid.Abstractions.Interfaces;
using Eway.Rapid.Abstractions.Models;
using Eway.Rapid.Abstractions.Request;
using Eway.Rapid.IntegrationTests.Utils;
using Xunit;

namespace Eway.Rapid.IntegrationTests
{
    [Collection("RapidClient collection")]
    public class DirectConnectionTests
    {

        readonly IRapidClient _rapidClient;
        public DirectConnectionTests(RapidClientFixture rapidFixture)
        {
            _rapidClient = rapidFixture.RapidClient;
        }

        [Fact]
        public async Task AuthorisationTransaction_Test()
        {
            var request = RequestGenerator.GenerateTransactionRequest(false, false);
            var response = await _rapidClient.CreateTransaction(request);

            Assert.NotNull(response);
            Assert.Null(response.Errors);
            Assert.NotNull(response.AuthorisationCode);
            AssertHelper.Assert_VerifyCustomerAddress(request.Customer, response.Customer);
            AssertHelper.Assert_VerifyCustomerAllFields(request.Customer, response.Customer);
        }

        [Fact]
        public async Task CancelAuthorisationTest()
        {
            var authorisationRequest = RequestGenerator.GenerateTransactionRequest(false, false);
            var authorisationResponse = await _rapidClient.CreateTransaction(authorisationRequest);

            var request = new CancelAuthorisationRequest
            {
                TransactionID = authorisationResponse.TransactionID.Value
            };

            var response = await _rapidClient.CancelAuthorisation(request);

            Assert.NotNull(response);
            Assert.True(response.TransactionStatus);
            Assert.NotNull(response.ResponseCode);
            Assert.NotNull(response.ResponseMessage);
        }

        [Fact]
        public async Task CreateDirectPayment_Test()
        {
            var request = RequestGenerator.GenerateTransactionRequest(false, true);

            var response = await _rapidClient.CreateTransaction(request);

            Assert.NotNull(response);
            Assert.Null(response.Errors);
            Assert.True(response.TransactionID.HasValue);
        }

        [Fact]
        public async Task CapturePaymentTest()
        {
            var authReq = RequestGenerator.GenerateTransactionRequest(false, false);
            var authRes = await _rapidClient.CreateTransaction(authReq);

            var request = new CaptureAuthorisationRequest
            {
                Payment = new Payment()
                {
                    TotalAmount = authRes.Payment.TotalAmount,
                    CurrencyCode = authRes.Payment.CurrencyCode,
                    InvoiceDescription = authRes.Payment.InvoiceDescription,
                    InvoiceNumber = authRes.Payment.InvoiceNumber,
                    InvoiceReference = authRes.Payment.InvoiceReference
                },
                TransactionID = authRes.TransactionID.Value
            };

            var response = await _rapidClient.CaptureAuthorisation(request);

            Assert.NotNull(response);
            Assert.True(response.TransactionStatus);
            Assert.NotNull(response.ResponseCode);
            Assert.NotNull(response.ResponseMessage);
        }

        [Fact]
        public async Task CreateAccessCode_Test()
        {
            var request = RequestGenerator.CreateAccessCodeReqeust();

            var response = await _rapidClient.CreateTransaction(request);

            Assert.NotNull(response);
            Assert.NotNull(response.AccessCode);
            Assert.NotNull(response.FormActionURL);
            AssertHelper.Assert_VerifyCustomerAllFields(request.Customer, response.Customer);
            AssertHelper.Assert_VerifyCustomerAllFields(request.Customer, response.Customer);
        }

        [Fact]
        public async Task CreateAccessCodeShared_Test()
        {
            var request = RequestGenerator.CreateAccessCodeSharedRequest();

            var response = await _rapidClient.CreateTransaction(request);

            Assert.NotNull(response);
            Assert.NotNull(response.AccessCode);
            Assert.NotNull(response.FormActionURL);
            Assert.NotNull(response.SharedPaymentUrl);
            AssertHelper.Assert_VerifyCustomerAllFields(request.Customer, request.Customer);
            AssertHelper.Assert_VerifyCustomerAllFields(request.Customer, request.Customer);
        }

        [Fact]
        public async Task GetAccessCodeResult_Test()
        {
            var createAccessCodeRequest = RequestGenerator.CreateAccessCodeReqeust();
            var createAccessCodeResponse = await _rapidClient.CreateTransaction(createAccessCodeRequest);

            var response = await _rapidClient.QueryAccessCode(createAccessCodeResponse.AccessCode);

            Assert.NotNull(response);
            Assert.NotEmpty(response.AccessCode);
        }

        [Fact]
        public async Task QueryTransactionByTransactionId_Test()
        {
            var transactionRequest = RequestGenerator.GenerateTransactionRequest(false, false);
            var transactionResponse = await _rapidClient.CreateTransaction(transactionRequest);

            var response = await _rapidClient.QueryTransactionByTransactionId(transactionResponse.TransactionID.Value.ToString());

            Assert.NotNull(response);
            Assert.True(response.Transactions.Count > 0);
        }

        [Fact]
        public async Task QueryTransactionByInvoiceNumber_Test()
        {
            var transactionRequest = RequestGenerator.GenerateTransactionRequest(false, false);
            transactionRequest.Payment.InvoiceNumber += new Random().Next(0, 99999);

            var transactionResponse = await _rapidClient.CreateTransaction(transactionRequest);

            var response = await _rapidClient.QueryTransactionByInvoiceNumber(transactionResponse.Payment.InvoiceNumber);

            Assert.NotNull(response);
            Assert.True(response.Transactions.Count > 0);
        }

        [Fact]
        public async Task QueryTransactionByInvoiceRef_Test()
        {
            var transactionRequest = RequestGenerator.GenerateTransactionRequest(false, false);
            transactionRequest.Payment.InvoiceReference += new Random().Next(100000, 999999);
            var transactionResponse = await _rapidClient.CreateTransaction(transactionRequest);

            var response = await _rapidClient.QueryTransactionByInvoiceRef(transactionResponse.Payment.InvoiceReference);

            Assert.NotNull(response);
            Assert.True(response.Transactions.Count > 0);
        }


        [Fact]
        public async Task CreateCustomer_Test()
        {
            var request = RequestGenerator.CreateCustomerRequest();

            var response = await _rapidClient.CreateCustomer(request);

            Assert.NotNull(response);
            Assert.Null(response.Errors);
            AssertHelper.Assert_VerifyCustomerAllFields(request.Customer, response.Customer);
            AssertHelper.Assert_VerifyCustoemrCardDetails(request.Customer, response.Customer);
        }

        [Fact]
        public async Task DirectCustomerSearch_Test()
        {
            var createCustomerRequest = RequestGenerator.CreateCustomerRequest();

            var createCustomerResponse = await _rapidClient.CreateCustomer(createCustomerRequest);

            var response = await _rapidClient.QueryCustomer(createCustomerResponse.Customer.TokenCustomerID.Value.ToString());

            Assert.NotNull(response);
            Assert.Null(response.Errors);
            AssertHelper.Assert_VerifyCustomerAllFields(createCustomerRequest.Customer, response.Customers.FirstOrDefault());
            AssertHelper.Assert_VerifyCustoemrCardDetails(createCustomerRequest.Customer, response.Customers.FirstOrDefault());
        }

        [Fact]
        public async Task DirectRefund_Test()
        {
            var directpaymentRequest = RequestGenerator.GenerateTransactionRequest(false, true);
            var directpaymentResponse = await _rapidClient.CreateTransaction(directpaymentRequest);

            var transactionId = directpaymentResponse.TransactionID.Value.ToString();
            var request = RequestGenerator.CreateDirectRefundRequest(transactionId);

            var response = await _rapidClient.Refund(transactionId, request);

            Assert.NotNull(response);
            Assert.StartsWith("A", response.ResponseMessage);
            AssertHelper.Assert_VerifyCustomerAllFields(request.Customer, response.Customer);
            AssertHelper.Assert_VerifyCustomerAddress(request.Customer, response.Customer);
            AssertHelper.Assert_VerifyCustoemrCardDetails(request.Customer, response.Customer);
        }

        [Fact]
        public async Task DirectThreeDSecureEnrol_Test()
        {
            var request = RequestGenerator.CreateDirect3DSEnrollRequest();

            var response = await _rapidClient.EnrolDirectThreeDSecure(request);

            Assert.NotNull(response);
            Assert.Null(response.Errors);
            Assert.False(string.IsNullOrEmpty(response.AccessCode));
            Assert.NotNull(response.Default3dsUrl);
        }

        [Fact]
        public async Task DirectThreeDSecureVerify_Test()
        {
            var enrollRequest = RequestGenerator.CreateDirect3DSEnrollRequest();
            var enrollResponse = await _rapidClient.EnrolDirectThreeDSecure(enrollRequest);

            var request = new VerifyDirectThreeDSecureRequest
            {
                AccessCode = enrollResponse.AccessCode
            };

            var response = await _rapidClient.VerifyDirectThreeDSecure(request);

            Assert.NotNull(response);
            Assert.False(response.Enrolled);
            Assert.NotNull(response.Errors);
        }

        [Fact]
        public async Task APICodeLookup_Test()
        {
            var request = new CodeLookupRequest
            {
                Language = "en",
                ErrorCodes = new List<string>()
                {
                    "D4406"
                }
            };

            var response = await _rapidClient.APICodeLookup(request);

            Assert.NotNull(response);
            Assert.Null(response.Errors);
            Assert.Equal("Error ", response.CodeDetails.First().DisplayMessage);
            Assert.Equal("D4406", response.CodeDetails.First().ErrorCode);
        }

        [Fact]
        public async Task CodeLookup_Test()
        {
            var request = new CodeLookupRequest
            {
                Language = "en",
                ErrorCodes = new List<string>()
                {
                    "S5000"
                }
            };

            var response = await _rapidClient.APICodeLookup(request);

            Assert.NotNull(response);
            Assert.Null(response.Errors);
            Assert.Equal("System Error", response.CodeDetails.First().DisplayMessage);
            Assert.Equal("S5000", response.CodeDetails.First().ErrorCode);
        }
    }
}
