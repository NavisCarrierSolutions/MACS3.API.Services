# A dead simple Stability Calculation sample
This sampe shows how to quickly perform a cloudbased calculation using Microsoft Visual Studio, C# and MACS3.Connected SDKs. MACS3.Connected SDK packages can be installed into any .NET project, provided that the package supports the same target framework as the project.

## 1. Create a project
* Open Visual Studio
* Create a Console App (C#)

## 2. Add the MACS3.Connected Stability SDK from nuget.org
* In Visual Studio select Tools > NuGet Package Manager > Package Manager Console menu command
* Once the console opens, check that the Default project drop-down list shows the project into which you want to install the package.
* Enter the command ```Install-Package MACS3.Connected.SDK.Stability```

## 3. Sample code

The full sample can be downloaded [here](samples)

```
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Macs3.Connected;
using Model = IO.Swagger.Model;

namespace MACS3.Connected.StabilityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var provider = new ApiKeyProvider {ApiKey = "YOUR-API-KEY"};

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
                                wdf: 295.0,
                                weight: 676.0
                            )
                        };

                        parameter.Calculate = new Model.WhatToCalculateParameter(
                            stability: true,
                            strength: false,
                            tanks: true
                        );

                        var userSettings = new Model.SettingsParameter { };
                        parameter.Settings = userSettings;
                        
                        // generate json fo Swagger/Postman
                        var json = JsonConvert.SerializeObject(parameter);
                        
                        var result = await apiClient.CalculateStabilityAsync(YOUR-IMO-NUMBER, parameter);
                    }
                    catch (ApiException e)
                    {
                    }
                }
            }).Wait();
        }
    }
}
```

In the above given sample, you just have to replace "YOUR-API-KEY" and YOUR-IMO-NUMBER with your specific data.

If the request is valid (http-status-code equals 200), you may continue and inspect the details in ```result``` accordingto the technical documentation at https://api.stability.macs3.com.

[back](README.md)
