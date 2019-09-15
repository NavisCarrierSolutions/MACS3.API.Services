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
using MACS3.Connected.SDK.Core;
using Model = MACS3.Connected.SDK.Model;

namespace StabilitySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var apiKey = "<YOUR-API-KEY>";
                var imoNumber = 1234567;
                var provider = new ApiKeyProvider { ApiKey = apiKey };

                using (var apiClient = await MACS3.Connected.SDK.Stability.API2.CreateClientAsync(provider))
                {
                    try
                    {
                        // Query vessel parameters
                        var availParameters = await apiClient.GetStabilityParametersAsync(imoNumber);

                        // Prepare parameterblock for calling the Stability Calculation
                        var parameter = new Model.CalculationsParameter();

                        // Add one container to the load
                        parameter.Containers = new List<Model.ContainerParameter>
                        {
                            new Model.ContainerParameter{
                                Id = "1",
                                Position = "170182",
                                TypeIsoCode = "22G0",
                                GrossWeight = 14,
                                ContainerId = "AAAU1234567"
                            }
                        };

                        // Add one tank to the load
                        parameter.Tanks = new List<Model.TankParameter>
                        {
                            new Model.TankParameter
                            {
                                Name = "5DBP", Density = 1.0250, PercentageFilled = 50, MaxFs = false
                            }
                        };

                        // Add one constant to the load
                        parameter.Constants = new List<Model.ConstantParameter>
                        {
                            new Model.ConstantParameter{
                                Name = "Deadweight constant",
                                Lcg = 79.27,
                                Tcg = 0,
                                Vcg = 7.65,
                                Wda = -4.6,
                                Wdf = 295,
                                Weight = 676
                            }
                        };

                        // Specify what you want to be calculated
                        parameter.Calculate = new Model.WhatToCalculateParameter
                        {
                            Stability = true,
                            Strength = false,
                            Tanks = true
                        };

                        // Fill in some vessel specific settings, here check e.g. availParameters.FreeboardModes[]
                        parameter.Settings = new Model.SettingsParameter { };
                        parameter.Settings.FreeboardMode = "Summer";

                        // View the payload e.g. for Swagger/Postman
                        // var json = JsonConvert.SerializeObject(parameter);

                        // Call the Stability Caluclation
                        var result = await apiClient.CalculateStabilityAsync(imoNumber, parameter);

                        // Inspect result for further processing
                    }
                    catch (ApiException)
                    {
                    }
                }
            }).Wait();
        }
    }
}
```

In the above given sample, you just have to replace "YOUR-API-KEY" and YOUR-IMO-NUMBER with your specific data.

If you run the above given sample and your request is valid (http-status-code equals 200), you may continue and inspect the details in ```result``` according to the technical documentation at https://api.stability.macs3.com.

[back](README.md)
