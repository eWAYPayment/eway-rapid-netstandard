# Eway Rapid .NET Standard Library

[![Latest version on NuGet][ico-version-3]](LICENSE.md)

[![https://img.shields.io/nuget/v/Eway.Rapid.Standard.Abstractions?color=blue&label=Eway.Rapid.Standard.Abstractions&logo=Eway.Rapid.Standard.Abstractions&logoColor=blue][ico-version-1]][link-nuget-1]

[![Latest version on NuGet][ico-version-2]][link-nuget-2]

[![Latest version on NuGet][ico-version]][link-nuget]

A .NET standard library to integrate with Eway's Rapid Payment API.

PR test
Sign up with Eway at:

- Australia: https://www.eway.com.au/
- New Zealand: https://eway.io/nz/
- Hong Kong: https://eway.io/hk/
- Malaysia: https://eway.io/my/
- Singapore: https://eway.io/sg/

For testing, get a free Eway Partner account: https://www.eway.com.au/developers

## Contents

- [Package Description](#package-description)
- [Install](#Install)
- [Usage](#Usage)
- [Change log](#Change-log)
- [License](#License)

## Package Description

Rapid's .NET Standard implementation is broken down into three packages:

  * [Eway.Rapid.Standard.Extensions.DependencyInjection](https://www.nuget.org/packages/Eway.Rapid.Extensions.Standard.DependencyInjection/)
  * [Eway.Rapid.Standard](https://www.nuget.org/packages/Eway.Rapid.Standard/)
  * [Eway.Rapid.Standard.Abstractions](https://www.nuget.org/packages/Eway.Rapid.Standard.Abstractions/)

### Eway.Rapid.Standard.Extensions.DependencyInjection:

This package should be used when the host application is using the ASP.NET CORE framework.  
It provides dependency injection for the `RapidClient`, and inherts functionality from the *Eway.Rapid.Standard* package.  

### Eway.Rapid.Standard:

This package should be used when the host application is not using the ASP.NET CORE framework, or a custom DI framework is preferred (*or DI is not used in the application*). It provides a implementation for the HTTP Client, and handles API calls on your behalf. The package inherits functionality from the *Eway.Rapid.Standard.Abstractions* package.

### Eway.Rapid.Standard.Abstractions:

This package should be used when you want full control of the Http Client, and API calls; but would like to use the pre-defined interface and protocol. The package contains data contracts, models, and Rapid endpoints.   Here you may create your own custom HTTP client, and handle API calls in a custom manner.  

## Install

Use one of the following command to install relevant package:

### Package Manager Console:

```
PM> Install-Package Eway.Rapid.Extensions.Standard.DependencyInjection 
```

OR

```
PM> Install-Package Eway.Rapid.Standard
```

.NET CLI Console:

```
> dotnet add package Eway.Rapid.Extensions.Standard.DependencyInjection
```

OR

```
> dotnet add package Eway.Rapid.Standard
```

## Usage

See [Eway's Rapid API Reference](https://eway.io/api-v3/) for more details.

### ASP.NET CORE Dependency Injection Configuration:

Sample app settings entry for `RapidClient's` configuration.  
Required nuget package: **Eway.Rapid.Standard.Extensions.DependencyInjection**.

```json
{
    "RapidClient":
    {
        "RapidEndPoint": "Sandbox",
        "ApiKey": "Rapid API Key",
        "Password": "Rapid API Password"
    }
}
```

Invoke the dedicated extension method for `RapidClient` in your app's configuration section.  

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddRapidClient();
}
```

You're now able to inject `IRapidClient` into services as required.  

```c#
public class HomeController : Controller
{
    IRapidClient rapidClient { get; set; }

    public HomeController(IRapidClient  rapidClient)
    {
        this.rapidClient = rapidClient;
    }
}
```

### Custom `RapidClient` Configuration:

Sample configuration when not using ASP.NET CORE's default dependency injector.  
Can be used with any other DI framework, or even without one.  
Required nuget package: **Eway.Rapid.Standard package**.  

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Eway.Rapid;
using Eway.Rapid.Abstractions.Interfaces;
using Eway.Rapid.Abstractions.Models;
using Eway.Rapid.Abstractions.Request;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            RapidOptions rapidOptions = new RapidOptions
            {
                ApiKey = "Rapid API KEY",
                Password = "Rapid API Password",
                RapidEndPoint = RapidEndpoints.SANDBOX
            };
            rapidOptions.ConfigureHttpClient(httpClient);
            IRapidClient rapidClient = new RapidClient(httpClient);
        }
    }
}
```

### Direct Connection using `RapidClient`:

Once you have configured the `RapidClient` using either the provided DI extension method, or via configuration; we can use the client as follows.  
Required nuget package, either: **Eway.Rapid.Standard.Extensions.DependencyInjection**, or: **Eway.Rapid.Standard package**.  

```c#
public void DirectPayment()
{
    // Create a direct connection request.
    DirectPaymentRequest transaction = new DirectPaymentRequest()
    {
        Customer = new DirectTokenCustomer()
        {
            CardDetails = new CardDetails()
            {
                Name = "John Smith",
                Number = "4444333322221111",
                ExpiryMonth = "12",
                ExpiryYear = "22",
                CVN = "123"
            }
        },
        Payment = new Payment()
        {
            TotalAmount = 1000
        },
        TransactionType = TransactionTypes.Purchase
    };

    // Use the RapidClient to process the request.
    var response = await rapidClient.CreateTransaction(transaction);

    // View the result of the direct connection response.
    Console.WriteLine(response.ResponseCode);
    Console.WriteLine(response.ResponseMessage);
    Console.WriteLine(response.TransactionID);
    Console.ReadLine();
}
```

## Change log

Please see [CHANGELOG](Changelog.md) for more information what has changed recently.

## License

The MIT License (MIT). Please see [License File](LICENSE.md) for more information.

[ico-version]: https://img.shields.io/nuget/v/Eway.Rapid.Extensions.Standard.DependencyInjection?color=blue&amp;label=Eway.Rapid.Extensions.Standard.DependencyInjection&amp;logo=Eway.Rapid.Extensions.Standard.DependencyInjection&amp;logoColor=blue
[ico-version-1]: https://img.shields.io/nuget/v/Eway.Rapid.Standard?color=blue&amp;label=Eway.Rapid.Standard&amp;logo=Eway.Rapid.Standard&amp;logoColor=blue
[link-nuget]: https://www.nuget.org/packages/Eway.Rapid.Extensions.Standard.DependencyInjection/
[link-nuget-1]: https://www.nuget.org/packages/Eway.Rapid.Standard/
[ico-version-2]: https://img.shields.io/nuget/v/Eway.Rapid.Standard.Abstractions?color=blue&amp;label=Eway.Rapid.Standard.Abstractions&amp;logo=Eway.Rapid.Standard.Abstractions&amp;logoColor=blue
[link-nuget-2]: https://www.nuget.org/packages/Eway.Rapid.Standard.Abstractions/
[ico-version-3]: https://img.shields.io/badge/license-MIT-green

