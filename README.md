# MACS3.Connected APIs

The MACS3.Connected REST APIs are for developers who want to integrate their application with MACS3.Connected and provide access to resources (data entities) via URI paths. To use a REST API, your application will make an HTTP request and parse the response. By default, the response format is JSON.

The MACS3.Connected APIs are based on the OpenAPI specification (formerly known as Swagger) and enable developers to generate server stubs and client SDKs for e.g. JavaScript, Java, C#, Objective C, Swift, C++ and more programming languages.

The following APIs are available:

* MACS3.Connected.Stability.SDK
* MACS3.Connected.Lashing.SDK
* MACS3.Connected.DangerousCargo.SDK

Technical documentation is available at:

* https://api.stability.macs3.com
* https://api.lashing.macs3.com
* https://api.dago.macs3.com

Find popular generators at [Swagger Codegen](https://swagger.io/tools/swagger-codegen) or [SwaggerHub](https://swagger.io/tools/swaggerhub).

## Sample: MACS3.Connected Stability Calculation with Microsoft Visual Studio and C# 7.1:

### Create a project
MACS3.Connected SDK packages can be installed into any .NET project, provided that the package supports the same target framework as the project.

### Add the MACS3.Connected Stability SDK from nuget.org
1. In Visual Studio select Tools > NuGet Package Manager > Package Manager Console menu command
2. Once the console opens, check that the Default project drop-down list shows the project into which you want to install the package.
3. Enter the command ```Install-Package nn```

### Get your API-KEY

### Use the SDK in your project:
```
using Macs3.Connected.Stability.SDK;
using Model = IO.Swagger.Model;

namespace Macs3.Connected.StabilityTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var provider = new ApiKeyProvider { ApiKey = "YOUR-API-KEY" };
            
            using (var apiClient = await Macs3.Connected.Stability.SDK.API2.CreateClientAsync(provider))
            {
                try
                {
                    Model.CalculationsParameter parameter;
                    Model.CalculationsResult result;

                    parameter = new Model.CalculationsParameter();
                    result = await apiClient.CalculateStabilityAsync(YOUR-IMO-NUMBER, parameter);
                }
                catch (ApiException)
                {
                }
            }
        }
    }
}
```

## Lashing calculation
This snippet explains how to perform a lashing calculation.

## DangerousCargo calculation
This snippet explains how to perform a dangerous-cargo calculation.
