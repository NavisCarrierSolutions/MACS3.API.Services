# MACS3.Connected Cloud-Services

The MACS3.Connected Cloud-Services enable users to perform stability, lashing and dangerous cargo calculations for vessels.

## Requirements

A MACS3.Connected account for your company  
A company related API-Key  
A company/vessel assignment (by IMO-Number)  
A usage-based billing plan  

## Quick Start: Explore the services through RESTful APIs

Our service documentations are based on the OpenAPI specification (aka Swagger) and can best be explored by using a REST Client like Swagger or Postman.

Swagger is has got the benefit of being a combination of REST Client and built-in documentation right at your fingertips - so it's a good point to start. More experienced users may prefer to use Postman as REST Client and use the Swagger documentation for reference. Postman is the most-used REST Client worldwide and gives you maximum flexibility and unlimited options.

You may follow our [Swagger](swagger.md) or [Postman](postman.md) guide for a quick start.

## Advanced: Integrate the services into your solution

You can easily integrate the services into your solutions by calling the RESTful APIs, so your application will make HTTP requests and parse the response. By default, the response format is JSON. To take the RESTful API complexity out of coding, you should use Client SDKs which provide the models and endpoints as reusable packages. 
 
If your coding platform is C#, you may use the SDKs published by Navis NCVS at nuget.org:
 
MACS3.Connected.SDK.Stability  
MACS3.Connected.SDK.Lashing  
MACS3.Connected.SDK.DangerousCargo  
 
If you are coding on another platform e.g. JavaScript, Java, C#, Objective C, Swift or C++, consider auto-generating the Client SDKs. The service documentations can be used as input by a variety of popular code-generators like [Swagger Codegen](https://swagger.io/tools/swagger-codegen) or [SwaggerHub](https://swagger.io/tools/swaggerhub) to generate Client SDKs.

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
                            position: "170182",
                            typeIsoCode: "22G0",
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
