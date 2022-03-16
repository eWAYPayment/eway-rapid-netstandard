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

        [Fact]
        public async Task GooglePay_Test()
        {
            var directPaymentRequest = new DirectPaymentRequest
            {
                PaymentInstrument = new RequestPaymentInstrument
                {
                    PaymentType = PaymentType.GooglePay,
                    WalletDetails = new RequestWalletDetails
                    {
                        Token = "{\"signature\":\"MEYCIQCeLZcBvb6O5Bv5d1c7+5u2kVvd6wV2cePr1eQX1sfBkAIhAOnx/0pJRfxErayYd9VkF+CcfI1ZQTDVkafp8UWO9/VG\",\"intermediateSigningKey\":{\"signedKey\":\"{\\\"keyValue\\\":\\\"MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAE7yzStowZVKJVZV3r1saLJvy+uS3r6uizb79tUSy8lJEBVkjWEb4/hJGz5NeTLu4I8Wi01TzKMcqW9eaI70d/QA\\\\u003d\\\\u003d\\\",\\\"keyExpiration\\\":\\\"1647987030638\\\"}\",\"signatures\":[\"MEUCIEIrSPKDJZm3nSgFBoz1bzyGd4GptFUZpu25rAXq9lZcAiEArb2GVWuVicdysjmcQaLz+f/sLf7spyHs8ynCC2EDgrk\\u003d\"]},\"protocolVersion\":\"ECv2\",\"signedMessage\":\"{\\\"encryptedMessage\\\":\\\"cGqnnPKbE8bSGnMtsXjs9h8q/kVfbXJFtTry7Fzv3AouYe0ZJRZ+PczqQre/kmZ93gv1DT0DEO2LSeMM4T7jp3pLE+tYat6WOPW/kpcBM5CrLrOF0VFPlA3ug1MbJL/eyxv1GmdkCKV4zq95UoJEK5dDSINt3Ghy8q71GAVoXdZIR9pAZxKcm0kTQ88USzWk2oplOJ0RiC2EZFVsmHk1LGHMAW5a+p/X0As/TpLsbu53m5Zon1B6rGS7NlzOPiLGMkdVrzXYidZqv5ir+laMapWUWWGldwMzsEuyFicbqyG8fKqXpNMfxJa2wK5Hr4jnLxjuvMKVb4uKrmP893FIssgi8fVWynGuqZvyMS/ZNPSXxS8M49DALgUlhZnMuxuGxPsrCEOI+0OJ01Op+8bU+BxMXVEqOfxKxweXmvVt35Q8wzY2jK/NHN4NfmF/+8Bmb8KxkcbgrNT+3ZFTPTADIer6TA0h/RM7AioXkV2O/WW7iBNMzLx+MXgXEtbrXNndtCwrP9eQF3VnPXApsAjN5Da6jmx/rE3KoRhR8BvC9SLDIuA37KN9TOWKL34lE5FjikUOYVKMXL00YRqSHSwZ\\\",\\\"ephemeralPublicKey\\\":\\\"BHLSnSxWuWaei4YizEnN36q2EISgeWHVlE4qoVHH5w2AqyzjeAYSZWNM1MRGJ8bKtXx1Bap9GJ6v70lfDKzcfeA\\\\u003d\\\",\\\"tag\\\":\\\"O/JB6DG0CXHXBIdIQRXzNlxzZqNVEsq/aXwFmc4Yi8A\\\\u003d\\\"}\"}"
                    }
                },
                Payment = new Payment
                {
                    TotalAmount = 100,
                    CurrencyCode = "AUD"
                },
                Capture = true,
                TransactionType = TransactionTypes.Purchase
            };
            var response = await _rapidClient.CreateTransaction(directPaymentRequest);

            Assert.NotNull(response);
            Assert.NotNull(response.ResponseCode);

            DateTime dateTime;
            bool tokenExpired = false;

            #region Expired date calculate and compare
            dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddMilliseconds(1647584174259L).ToLocalTime();
            tokenExpired = dateTime.CompareTo(new DateTime().ToLocalTime()) < 0;
            #endregion

            //The GPay token has expired time, so when it is fresh, we can get "A2000" success code.
            //But when it is expired, it will return "S5017" token expired.
            if (tokenExpired)
            {
                Assert.Equal("S5017", response.ResponseMessage);
            }
            else
            {
                Assert.Null(response.Errors);
                Assert.Equal("A2000", response.ResponseMessage);
            }

        }
    }
}
