# MACS3.Connected APIs

We offer the following APIs to access...

* MACS3.Connected.Stability.SDK
* MACS3.Connected.Lashing.SDK
* MACS3.Connected.DangerousCargo.SDK

Our MACS3.Connected APIs are documented according to the OpenAPI specification (formerly known as Swagger) and enables technical users to generate server stubs and client SDKs for e.g. JavaScript, Java, C#, Objective C, Swift, Android and more programming languages.

Our technical documentation is available at:

* https://api.stability.macs3.com
* https://api.lashing.macs3.com
* https://api.dago.macs3.com

Popular generators are [Swagger Codegen](https://swagger.io/tools/swagger-codegen) or [SwaggerHub](https://swagger.io/tools/swaggerhub).

## Basic usage of the different MACS3.Connected SDKs in C# 7.1:

## Stability calculation
This snippet explains how to perform a stability calculation

### Create a project
MACS3.Connected SDK packages can be installed into any .NET project, provided that the package supports the same target framework as the project.

### Add the MACS3.Connected Stability SDK from nuget.org:
1. In Visual Studio select Tools > NuGet Package Manager > Package Manager Console menu command
2. Once the console opens, check that the Default project drop-down list shows the project into which you want to install the package.
3. Enter the command ```Install-Package nn```

### Create an API-KEY

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
