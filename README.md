# Eway Rapid .NET Standard Library

[![License: MIT][ico-version-3]](LICENSE.md)
[![Eway.Rapid.Standard.Abstractions on NuGet][ico-version-2]][link-nuget-2]
[![Eway.Rapid.Standard on NuGet][ico-version-1]][link-nuget-1]
[![Eway.Rapid.Extensions.Standard.DependencyInjection on NuGet][ico-version]][link-nuget]

A .NET Standard library for integrating with Eway's [Rapid Payment API](https://eway.io/api-v3/). It handles authentication, serialisation, and HTTP communication so you can focus on your payment flows.

Sign up for an Eway merchant account at:

| Region | URL |
|---|---|
| Australia | https://www.eway.com.au/ |
| New Zealand | https://eway.io/nz/ |
| Hong Kong | https://eway.io/hk/ |
| Malaysia | https://eway.io/my/ |
| Singapore | https://eway.io/sg/ |

> **Sandbox testing:** Get a free Eway Partner sandbox account at https://www.eway.com.au/developers

---

## Contents

- [Packages](#packages)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
  - [ASP.NET Core (Dependency Injection)](#aspnet-core-dependency-injection)
  - [Standalone / Console / Custom DI](#standalone--console--custom-di)
- [Usage Examples](#usage-examples)
  - [Direct Payment (Purchase)](#direct-payment-purchase)
  - [Authorise Only](#authorise-only)
  - [Capture an Authorisation](#capture-an-authorisation)
  - [Cancel an Authorisation](#cancel-an-authorisation)
  - [Refund a Transaction](#refund-a-transaction)
  - [Transparent Redirect](#transparent-redirect)
  - [Responsive Shared Page](#responsive-shared-page)
  - [Query Access Code Result](#query-access-code-result)
  - [Query Transactions](#query-transactions)
  - [Token Customers](#token-customers)
  - [3D Secure](#3d-secure)
  - [API Code Lookup](#api-code-lookup)
- [Error Handling](#error-handling)
- [Endpoints Reference](#endpoints-reference)
- [Change Log](#change-log)
- [License](#license)

---

## Packages

The library is split into three NuGet packages. Choose the one that fits your application:

| Package | Use when… |
|---|---|
| **Eway.Rapid.Extensions.Standard.DependencyInjection** | Your app uses ASP.NET Core's built-in DI container. Includes everything in `Eway.Rapid.Standard`. |
| **Eway.Rapid.Standard** | You are using a console app, a custom DI framework, or no DI at all. Includes everything in `Eway.Rapid.Standard.Abstractions`. |
| **Eway.Rapid.Standard.Abstractions** | You want to manage the `HttpClient` yourself and only need the data contracts, models, and endpoint constants. |

---

## Prerequisites

- .NET Standard 2.0+ compatible runtime (.NET 6 / .NET 8 recommended)
- An Eway API Key and Password (available from your Eway merchant portal or sandbox account)

---

## Installation

**Package Manager Console:**

```powershell
# ASP.NET Core apps
PM> Install-Package Eway.Rapid.Extensions.Standard.DependencyInjection

# Console / non-DI apps
PM> Install-Package Eway.Rapid.Standard
```

**.NET CLI:**

```bash
# ASP.NET Core apps
dotnet add package Eway.Rapid.Extensions.Standard.DependencyInjection

# Console / non-DI apps
dotnet add package Eway.Rapid.Standard
```

---

## Configuration

### ASP.NET Core (Dependency Injection)

**1. Add credentials to `appsettings.json`:**

```json
{
  "RapidClient": {
    "RapidEndPoint": "Sandbox",
    "ApiKey": "<your-api-key>",
    "Password": "<your-api-password>",
    "ApiVersion": 47
  }
}
```

Set `RapidEndPoint` to `"Production"` when going live.

**2. Register the client in `Program.cs` / `Startup.cs`:**

```csharp
builder.Services.AddRapidClient();
```

You can also bind a custom configuration section:

```csharp
builder.Services.AddRapidClient("MyPaymentSettings");
```

**3. Inject `IRapidClient` wherever you need it:**

```csharp
public class PaymentService
{
    private readonly IRapidClient _rapidClient;

    public PaymentService(IRapidClient rapidClient)
    {
        _rapidClient = rapidClient;
    }
}
```

---

### Standalone / Console / Custom DI

Required package: **Eway.Rapid.Standard**

```csharp
using System.Net.Http;
using Eway.Rapid;
using Eway.Rapid.Abstractions.Interfaces;

var httpClient = new HttpClient();
var options = new RapidOptions
{
    ApiKey    = "<your-api-key>",
    Password  = "<your-api-password>",
    RapidEndPoint = RapidEndpoints.SANDBOX, // or RapidEndpoints.PRODUCTION
    ApiVersion = 47
};
options.ConfigureHttpClient(httpClient);

IRapidClient rapidClient = new RapidClient(httpClient);
```

`ConfigureHttpClient` sets the base URL, Basic Auth header, and API version header automatically.

---

## Usage Examples

All methods on `IRapidClient` are `async` and accept an optional `CancellationToken`.

### Direct Payment (Purchase)

Charge a card directly from your server. Card data never touches your own servers if you use Secure Fields instead.

```csharp
using Eway.Rapid.Abstractions.Models;
using Eway.Rapid.Abstractions.Request;

var request = new DirectPaymentRequest
{
    Customer = new DirectTokenCustomer
    {
        FirstName = "John",
        LastName  = "Smith",
        CardDetails = new CardDetails
        {
            Name        = "John Smith",
            Number      = "4444333322221111",
            ExpiryMonth = "12",
            ExpiryYear  = "30",
            CVN         = "123"
        }
    },
    Payment = new Payment
    {
        TotalAmount      = 1000,          // Amount in cents (e.g. 1000 = $10.00 AUD)
        CurrencyCode     = "AUD",
        InvoiceNumber    = "INV-001",
        InvoiceReference = "Order #42"
    },
    TransactionType = TransactionTypes.Purchase,
    CustomerIP      = "1.2.3.4"
};

var response = await rapidClient.CreateTransaction(request);

Console.WriteLine(response.ResponseCode);
Console.WriteLine(response.ResponseMessage);
Console.WriteLine(response.TransactionID);
```

> **Amount format:** `TotalAmount` is always expressed in the lowest currency denomination (cents). $10.00 AUD = `1000`.

---

### Authorise Only

Reserves funds on the card without capturing. Useful for hotel pre-authorisations or order holds.

```csharp
var request = new DirectPaymentRequest
{
    Customer = new DirectTokenCustomer
    {
        CardDetails = new CardDetails
        {
            Name        = "Jane Doe",
            Number      = "4444333322221111",
            ExpiryMonth = "12",
            ExpiryYear  = "30",
            CVN         = "123"
        }
    },
    Payment = new Payment
    {
        TotalAmount  = 5000,
        CurrencyCode = "AUD"
    },
    TransactionType = TransactionTypes.Purchase,
    Capture = false   // Authorise only – do NOT capture yet
};

var response = await rapidClient.CreateTransaction(request);
// Store response.TransactionID to capture or cancel later
```

---

### Capture an Authorisation

Finalise a previously authorised transaction.

```csharp
using Eway.Rapid.Abstractions.Request;

var request = new CaptureAuthorisationRequest
{
    TransactionID = 12345678,
    Payment = new Payment
    {
        TotalAmount  = 5000,
        CurrencyCode = "AUD"
    }
};

var response = await rapidClient.CaptureAuthorisation(request);

Console.WriteLine(response.ResponseCode);
Console.WriteLine(response.ResponseMessage);
Console.WriteLine(response.TransactionID);
```

---

### Cancel an Authorisation

Release the reserved funds without capturing.

```csharp
var request = new CancelAuthorisationRequest
{
    TransactionID = 12345678
};

var response = await rapidClient.CancelAuthorisation(request);

Console.WriteLine(response.ResponseCode);
Console.WriteLine(response.ResponseMessage);
Console.WriteLine(response.TransactionID);
```

---

### Refund a Transaction

Refund all or part of a captured transaction.

```csharp
var request = new DirectRefundRequest
{
    Refund = new Refund
    {
        TotalAmount  = 500,   // Partial refund of $5.00
        CurrencyCode = "AUD",
        InvoiceNumber = "INV-001"
    }
};

var response = await rapidClient.Refund("12345678", request);

Console.WriteLine(response.ResponseCode);
Console.WriteLine(response.ResponseMessage);
Console.WriteLine(response.TransactionID);
```

---

### Transparent Redirect

Eway hosts the payment form. The customer submits card details directly to Eway; your server receives only a result via redirect.

**Step 1 – Create an access code:**

```csharp
var request = new CreateTransparentRedirectRequest
{
    Customer = new Customer
    {
        FirstName = "John",
        LastName  = "Smith"
    },
    Payment = new Payment
    {
        TotalAmount  = 1000,
        CurrencyCode = "AUD"
    },
    RedirectUrl     = "https://yoursite.com/payment/result",
    TransactionType = TransactionTypes.Purchase
};

var response = await rapidClient.CreateTransaction(request);
// response.FormActionURL  – POST the card form to this URL
// response.AccessCode     – include as a hidden field in the form
```

**Step 2 – When Eway redirects back to your `RedirectUrl`, query the result:**

```csharp
// accessCode comes from the query string: ?AccessCode=...
var result = await rapidClient.QueryAccessCode(accessCode);

Console.WriteLine(result.ResponseCode);
Console.WriteLine(result.ResponseMessage);
Console.WriteLine(result.TransactionID);
```

---

### Responsive Shared Page

Eway hosts a complete, mobile-responsive checkout page. Redirect the customer to the URL returned by the API.

```csharp
var request = new CreateResponsiveSharedRequest
{
    Customer = new Customer
    {
        FirstName = "John",
        LastName  = "Smith",
        Email     = "john@example.com"
    },
    Payment = new Payment
    {
        TotalAmount      = 2500,
        CurrencyCode     = "AUD",
        InvoiceNumber    = "INV-002",
        InvoiceReference = "Order #43"
    },
    RedirectUrl          = "https://yoursite.com/payment/result",
    CancelUrl            = "https://yoursite.com/cart",
    TransactionType      = TransactionTypes.Purchase,
    LogoUrl              = "https://yoursite.com/logo.png",
    HeaderText           = "Complete your payment",
    Language             = "EN",
    CustomerReadOnly     = false,
    VerifyCustomerEmail  = true,
    VerifyCustomerPhone  = false
};

var response = await rapidClient.CreateTransaction(request);

// Redirect the customer to response.SharedPaymentUrl
```

Query the result after the customer is redirected back using `QueryAccessCode` (same as Transparent Redirect, Step 2).

---

### Query Access Code Result

Retrieve the outcome of a Transparent Redirect or Responsive Shared Page transaction.

```csharp
var result = await rapidClient.QueryAccessCode("your-access-code");

Console.WriteLine($"Transaction ID : {result.TransactionID}");
Console.WriteLine($"Response code  : {result.ResponseCode}");
```

---

### Query Transactions

Look up transactions after the fact for reconciliation or support.

```csharp
// By Transaction ID
var byId = await rapidClient.QueryTransactionByTransactionId("12345678");

// By Invoice Number
var byInvoice = await rapidClient.QueryTransactionByInvoiceNumber("INV-001");

// By Invoice Reference
var byRef = await rapidClient.QueryTransactionByInvoiceRef("Order #42");

foreach (var tx in byId.Transactions)
{
    Console.WriteLine(tx.ResponseCode);
    Console.WriteLine(tx.ResponseMessage);
    Console.WriteLine(tx.TransactionID);
}
```

---

### Token Customers

Store card details as a token so repeat customers can pay without re-entering card details.

**Create a token customer:**

```csharp
var request = new CustomerRequest
{
    Customer = new DirectTokenCustomer
    {
        FirstName = "Jane",
        LastName  = "Doe",
        Email     = "jane@example.com",
        CardDetails = new CardDetails
        {
            Name        = "Jane Doe",
            Number      = "4444333322221111",
            ExpiryMonth = "12",
            ExpiryYear  = "30",
            CVN         = "123"
        }
    }
};

var response = await rapidClient.CreateCustomer(request);
// Store response.Customer.TokenCustomerID for future payments
// response.Customer is a DirectTokenCustomer
```

**Charge using a stored token:**

```csharp
var paymentRequest = new DirectPaymentRequest
{
    Customer = new DirectTokenCustomer
    {
        TokenCustomerID = 9876543210123456L  // long – use the value from CreateCustomer response
    },
    Payment = new Payment
    {
        TotalAmount  = 1500,
        CurrencyCode = "AUD"
    },
    TransactionType = TransactionTypes.Purchase
};

var paymentResponse = await rapidClient.CreateTransaction(paymentRequest);
```

**Update a token customer:**

```csharp
var updateRequest = new CustomerRequest
{
    Customer = new DirectTokenCustomer
    {
        TokenCustomerID = 9876543210123456L,  // long – must match the stored token ID
        CardDetails = new CardDetails
        {
            Name        = "Jane Doe",
            Number      = "4444333322221111",
            ExpiryMonth = "06",
            ExpiryYear  = "30",
            CVN         = "456"
        }
    }
};

await rapidClient.UpdateCustomer(updateRequest);
```

**Query a token customer:**

```csharp
var response = await rapidClient.QueryCustomer("9876543210123456");
var customer = response.Customers[0];
Console.WriteLine($"{customer.FirstName} {customer.LastName} – card ending {customer.CardDetails?.Number?.Substring(customer.CardDetails.Number.Length - 4)}");
```

---

### 3D Secure

Perform 3D Secure 2 authentication before charging the card.

**Step 1 – Enrol:**

```csharp
var enrolRequest = new EnrolDirectThreeDSecureRequest
{
    Customer = new DirectTokenCustomer
    {
        CardDetails = new CardDetails
        {
            Name        = "John Smith",
            Number      = "4444333322221111",
            ExpiryMonth = "12",
            ExpiryYear  = "30",
            CVN         = "123"
        }
    },
    Payment = new Payment
    {
        TotalAmount  = 1000,
        CurrencyCode = "AUD"
    },
    RedirectUrl = "https://yoursite.com/3ds/callback"
};

var enrolResponse = await rapidClient.EnrolDirectThreeDSecure(enrolRequest);
// If a challenge is required, redirect the customer to enrolResponse.Default3dsUrl
// The enrolResponse.AccessCode is needed for the verify step
```

**Step 2 – Verify after the customer returns:**

Eway returns an `AccessCode` parameter to your `RedirectUrl` after the 3DS challenge. Pass it to the verify call:

```csharp
// accessCode comes from the 3DS callback query string
var verifyRequest = new VerifyDirectThreeDSecureRequest
{
    AccessCode = accessCode
};

var verifyResponse = await rapidClient.VerifyDirectThreeDSecure(verifyRequest);
```

---

### API Code Lookup

Decode one or more Eway response codes into human-readable descriptions.

```csharp
var request = new CodeLookupRequest
{
    Language   = "EN",
    ErrorCodes = new List<string> { "V6000", "A2000" }  // one or more codes to look up
};

var response = await rapidClient.APICodeLookup(request);
// response.CodeDetails is a List<ErrorCodeDetails>
foreach (var detail in response.CodeDetails ?? new List<ErrorCodeDetails>())
{
    Console.WriteLine($"{detail.ErrorCode}: {detail.DisplayMessage}");
}
```

---

## Error Handling

Every response inherits from `BaseResponse` which exposes:

| Property | Description |
|---|---|
| `Errors` | Comma-separated list of Eway error codes for validation/request failures, `null` on success. |

For transaction responses, also check:

| Property | Description |
|---|---|
| `ResponseCode` | Eway two-character response code (e.g. `"00"` = approved). |
| `ResponseMessage` | Comma-separated list of response message codes (e.g. `"A2000"`). Use `APICodeLookup` to decode them. |

> **Important:** The client calls `EnsureSuccessStatusCode()` internally. Any non-2xx HTTP response (e.g. `401 Unauthorized`, `500 Internal Server Error`) throws an `HttpRequestException`. Wrap your calls accordingly.

```csharp
try
{
    var response = await rapidClient.CreateTransaction(request);

    Console.WriteLine(response.ResponseCode);
    Console.WriteLine(response.ResponseMessage);
    Console.WriteLine(response.TransactionID);
}
catch (HttpRequestException ex)
{
    // Non-2xx HTTP response (e.g. 401 Unauthorized, 500 Server Error)
    Console.WriteLine($"HTTP error: {ex.Message}");
}
```

---

## Endpoints Reference

`RapidEndpoints` provides the following constants:

| Constant | Value |
|---|---|
| `RapidEndpoints.PRODUCTION` | `https://api.ewaypayments.com/` |
| `RapidEndpoints.SANDBOX` | `https://api.sandbox.ewaypayments.com/` |
| `RapidEndpoints.PRODUCTION_ALIAS` | `"Production"` (use in `appsettings.json`) |
| `RapidEndpoints.SANDBOX_ALIAS` | `"Sandbox"` (use in `appsettings.json`) |

You can also supply any fully-qualified HTTPS URL as `RapidEndPoint` if you need to target a custom environment.

---

## Change Log

Please see [CHANGELOG](Changelog.md) for a full history of changes.

## License

The MIT License (MIT). Please see [License File](LICENSE.md) for more information.

[ico-version]: https://img.shields.io/nuget/v/Eway.Rapid.Extensions.Standard.DependencyInjection?color=blue&label=Eway.Rapid.Extensions.Standard.DependencyInjection&logo=nuget&logoColor=blue
[ico-version-1]: https://img.shields.io/nuget/v/Eway.Rapid.Standard?color=blue&label=Eway.Rapid.Standard&logo=nuget&logoColor=blue
[ico-version-2]: https://img.shields.io/nuget/v/Eway.Rapid.Standard.Abstractions?color=blue&label=Eway.Rapid.Standard.Abstractions&logo=nuget&logoColor=blue
[ico-version-3]: https://img.shields.io/badge/license-MIT-green
[link-nuget]: https://www.nuget.org/packages/Eway.Rapid.Extensions.Standard.DependencyInjection/
[link-nuget-1]: https://www.nuget.org/packages/Eway.Rapid.Standard/
[link-nuget-2]: https://www.nuget.org/packages/Eway.Rapid.Standard.Abstractions/

