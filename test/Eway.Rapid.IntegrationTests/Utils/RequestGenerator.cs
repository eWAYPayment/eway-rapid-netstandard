using System.Collections.Generic;
using Eway.Rapid.Abstractions.Models;
using Eway.Rapid.Abstractions.Request;

namespace Eway.Rapid.IntegrationTests
{
    public class RequestGenerator
    {
        internal static DirectPaymentRequest GenerateTransactionRequest(bool saveCustomer, bool capture)
        {
            return new DirectPaymentRequest
            {
                Customer = CreateCustomer(),
                ShippingAddress = new ShippingAddress
                {
                    Street1 = "Level 5",
                    Street2 = "369 Queen Street",
                    City = "Sydney",
                    State = "NSW",
                    Country = "au",
                    PostalCode = "2000"
                },
                Items = CreateLineItems(),
                Options = new List<Option>
                {
                    new Option{ Value = "Option1" },
                    new Option{ Value = "Option2"}
                },
                Payment = new Payment
                {
                    TotalAmount = 1000,
                    InvoiceNumber = "Inv 21540",
                    InvoiceDescription = "Individual Invoice Description",
                    InvoiceReference = "513456",
                    CurrencyCode = "AUD"
                },
                TransactionType = TransactionTypes.Purchase,
                RedirectUrl = "http://www.eway.com.au",
                DeviceID = "D1234",
                PartnerID = "ID",
                CustomerIP = "127.0.0.1",
                SaveCustomer = saveCustomer,
                Capture = capture
            };
        }

        internal static CreateTransparentRedirectRequest CreateAccessCodeReqeust()
        {
            return CreateAccessCodeSharedRequest();
        }

        internal static CreateResponsiveSharedRequest CreateAccessCodeSharedRequest()
        {
            return new CreateResponsiveSharedRequest
            {
                Customer = CreateCustomer(),
                ShippingAddress = CreateShippingAddress(),
                Items = CreateLineItems(),
                Options = new List<Option>
                {
                    new Option{ Value = "Option1" },
                    new Option{ Value = "Option2"}
                },
                Payment = new Payment
                {
                    TotalAmount = 1000,
                    InvoiceNumber = "Inv 21540",
                    InvoiceDescription = "Individual Invoice Description",
                    InvoiceReference = "513456",
                    CurrencyCode = "AUD"
                },
                TransactionType = TransactionTypes.Purchase,
                RedirectUrl = "http://www.eway.com.au",
                DeviceID = "D1234",
                PartnerID = "ID",
                CustomerIP = "127.0.0.1",
                LogoUrl = "https://mysite.com/images/logo4eway.jpg",
                HeaderText = "My Site Header Text",
                CustomerReadOnly = true,
                CustomView = CustomView.Bootstrap,
                VerifyCustomerEmail = false,
                VerifyCustomerPhone = false,
                SaveCustomer = false
            };
        }

        internal static CustomerRequest CreateCustomerRequest()
        {
            return new CustomerRequest
            {
                Customer = CreateCustomer()
            };
        }

        internal static DirectRefundRequest CreateDirectRefundRequest(string transactionId)
        {
            var request = new DirectRefundRequest
            {
                PartnerID = "P123",
                DeviceID = "D1234",
                Refund = new Refund()
                {
                    TotalAmount = 100,
                    InvoiceNumber = "Inv 21540",
                    InvoiceDescription = "Individual Invoice Description",
                    InvoiceReference = "513456",
                    CurrencyCode = "AUD",
                    TransactionID = transactionId
                },
                Customer = CreateCustomer(),
                ShippingAddress = CreateShippingAddress(),
                Items = CreateLineItems(),
                Options = new List<Option>
                {
                    new Option{ Value = "Option1" },
                    new Option{ Value = "Option2"}
                }
            };
            request.Customer.CardDetails = new CardDetails()
            {
                ExpiryMonth = "12",
                ExpiryYear = "25"
            };
            return request;
        }

        internal static EnrolDirectThreeDSecureRequest CreateDirect3DSEnrollRequest()
        {
            return new EnrolDirectThreeDSecureRequest
            {
                Customer = CreateCustomer(),
                ShippingAddress = CreateShippingAddress(),
                Items = CreateLineItems(),
                Payment = new Payment
                {
                    TotalAmount = 100,
                    InvoiceNumber = "Inv 21540",
                    InvoiceDescription = "Individual Invoice Description",
                    InvoiceReference = "513456",
                    CurrencyCode = "AUD"
                },
                RedirectUrl = "http://www.ewaypayments.com",
                SecuredCardData = "",
            };
        }


        private static DirectTokenCustomer CreateCustomer()
        {
            return new DirectTokenCustomer
            {
                CardDetails = new CardDetails
                {
                    Name = "John Smith",
                    Number = "4444333322221111",
                    ExpiryMonth = "12",
                    ExpiryYear = "25",
                    CVN = "123"
                },
                Street1 = "Level 5",
                Street2 = "369 Queen Street",
                City = "Sydney",
                State = "NSW",
                Country = "au",
                PostalCode = "2000",
                Reference = "A12345",
                Title = "Mr.",
                FirstName = "John",
                LastName = "Smith",
                CompanyName = "Demo Shop 123",
                JobDescription = "Developer",
                Phone = "09 889 0986",
                Mobile = "09 889 6542",
                Email = "demo@example.org",
                Url = "http://www.ewaypayments.com",
                Comments = "",
                Fax = ""
            };
        }

        private static ShippingAddress CreateShippingAddress()
        {
            return new ShippingAddress
            {
                Street1 = "Level 5",
                Street2 = "369 Queen Street",
                City = "Sydney",
                State = "NSW",
                Country = "au",
                PostalCode = "2000"
            };
        }

        private static List<LineItem> CreateLineItems()
        {
            return new List<LineItem>()
            {
                new LineItem()
                {
                    SKU = "12345678901234567890",
                    Description = "Item Description 1",
                    Quantity = 1,
                    UnitCost = 400,
                    Tax = 100,
                    Total = 500
                },
                new LineItem()
                {
                    SKU = "123456789012",
                    Description = "Item Description 2",
                    Quantity = 1,
                    UnitCost = 400,
                    Tax = 100,
                    Total = 500
                }
            };
        }
    }
}
