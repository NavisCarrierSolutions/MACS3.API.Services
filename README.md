# Navis NCVS Cloud services - MACS3.Connected RESTful API

The MACS3.Connected REST APIs enable developers to generate server stubs and client SDKs for e.g. JavaScript, Java, C#, Objective C, Swift, C++ and many more programming languages. To use a REST API, your application will make an HTTP request and parse the response. By default, the response format is JSON.

The following APIs are available:

* MACS3.Connected.SDK.Stability
* MACS3.Connected.SDK.Lashing
* MACS3.Connected.SDK.DangerousCargo

The technical documentation is based on the OpenAPI specification (formerly known as Swagger) and can be used by a variety of popular code-generators like [Swagger Codegen](https://swagger.io/tools/swagger-codegen) or [SwaggerHub](https://swagger.io/tools/swaggerhub).

Technical documentation is available at:

* https://api.stability.macs3.com
* https://api.lashing.macs3.com
* https://api.dago.macs3.com

[Postman](postman.md)

## Sample: MACS3.Connected Stability Calculation with Microsoft Visual Studio and C# 7.1:

### Create a project
MACS3.Connected SDK packages can be installed into any .NET project, provided that the package supports the same target framework as the project.

### Add the MACS3.Connected Stability SDK from nuget.org
1. In Visual Studio select Tools > NuGet Package Manager > Package Manager Console menu command
2. Once the console opens, check that the Default project drop-down list shows the project into which you want to install the package.
3. Enter the command ```Install-Package MACS3.Connected.SDK.Stability```

### Get your API-KEY

### Use the SDK in your project:
```
using MACS3.Connected.SDK.Stability;
using Model = IO.Swagger.Model;

namespace MACS3.Connected.StabilityTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var provider = new ApiKeyProvider { ApiKey = "YOUR-API-KEY" };
            
            using (var apiClient = await MACS3.Connected.SDK.Stability.API2.CreateClientAsync(provider))
            {
                try
                {
                    var parameter = new Model.CalculationsParameter();

                    parameter.Containers = new List<Model.ContainerParameter>
                    {
                        new Model.ContainerParameter(
                            id: 1,
                            position:
                            "170182", typeIsoCode: "22G0",
                            grossWeight: 14,
                            containerId: "AAAU1234567"
                        )
                    };

                    parameter.Tanks = new List<Model.TankParameter>
                    {
                        new Model.TankParameter(name: "5DBP", density: 1.0250, percentageFilled: 50, maxFs: false)
                    };

                    parameter.Constants = new List<Model.ConstantParameter>
                    {
                        new Model.ConstantParameter(
                            name: "Deadweight constant",
                            lcg: 79.27,
                            tcg: 0,
                            vcg: 7.65,
                            wda: -4.6,
                            wdf: 295,
                            weight: 676
                        )
                    };

                    parameter.Calculate = new Model.WhatToCalculateParameter(
                        stability: true,
                        strength: false,
                        tanks: true
                        );

                    parameter.Settings = new Model.SettingsParameter();

                    var result = await apiClient.CalculateStabilityAsync(YOUR_IMO_NUMBER, parameter);
                }
                catch (ApiException e)
                {
                }
            }
        }
    }
}
```

This is a dead simple stability-calculation sample. For more, please contact us or check out the technical documentation at https://api.stability.macs3.com

## Lashing calculation
This snippet explains how to perform a lashing calculation.

## DangerousCargo calculation
This snippet explains how to perform a dangerous-cargo calculation.
