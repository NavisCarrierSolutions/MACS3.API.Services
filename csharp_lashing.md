# A dead simple Lashing Calculation sample
This sampe shows how to quickly perform a cloudbased calculation using Microsoft Visual Studio, C# and MACS3.Connected SDKs. MACS3.Connected SDK packages can be installed into any .NET project, provided that the package supports the same target framework as the project.

## 1. Create a project
* Open Visual Studio
* Create a Console App (C#)

## 2. Add the MACS3.Connected Lashing SDK from nuget.org
* In Visual Studio select Tools > NuGet Package Manager > Package Manager Console menu command
* Once the console opens, check that the Default project drop-down list shows the project into which you want to install the package.
* Enter the command ```Install-Package MACS3.Connected.SDK.Lashing```

## 3. Sample code

The full sample can be downloaded [here](samples)

```
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MACS3.Connected.SDK.Core;
using Model = MACS3.Connected.SDK.Model;

namespace LashingSample
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

                using (var apiClient = await MACS3.Connected.SDK.Lashing.API2.CreateClientAsync(provider))
                {
                    try
                    {
                        // Query vessel parameters
                        var lashParameters = await apiClient.GetDynamicLashParametersAsync(imoNumber);
                        var vesselSpeed = (double)lashParameters.Parameters.SingleOrDefault(o => o.ValueType == Model.ParameterInfo.ValueTypeEnum.SpeedInKnots).DefaultValue;

                        // Prepare parameterblock for calling the Lash Calculation
                        var parameters = new Model.LashingParameters
                        {
                            Parameters = new Model.DynamicParameters
                            {
                                Gm = 5,
                                Draft = 10,
                                VesselSpeed = vesselSpeed /* 15.0*/,
                                WindSpeed = 40.0
                            }
                        };

                        // Add two container to the load
                        parameters.Containers = new List<Model.ContainerParameter>
                        {
                            new Model.ContainerParameter
                            {
                                Id = "1",
                                ContainerId = "AAAU1234568",
                                TypeIsoCode = "42G0",
                                GrossWeight = 10.1,
                                Position = "020206",
                                RelativeVcg = 0.50,
                                Height = 2.591,
                                Length = 12.192,
                                Width = 2.438
                            },
                            new Model.ContainerParameter
                            {
                                Id = "2",
                                ContainerId = "AAAU1234569",
                                TypeIsoCode = "42G0",
                                GrossWeight = 10.1,
                                Position = "020282",
                                RelativeVcg = 0.50,
                                Height = 2.591,
                                Length = 12.192,
                                Width = 2.438
                            },
                        };

                        // Specify what needs to be calculated
                        parameters.Calculate = new Model.WhatToCalculateParameterLashing
                        {
                            LoadableWeights = true,
                            PlacedLashBars = true
                        };

                        // View the payload e.g. for Swagger/Postman
                        //var json = JsonConvert.SerializeObject(parameters);

                        // Call the Lash Calculation
                        var result = await apiClient.PerformLashCalculationsAsync(imoNumber, parameters);

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

If you run the above given sample and your request is valid (http-status-code equals 200), you may continue and inspect the details in ```result``` according to the technical documentation at https://api.lashing.macs3.com.

[back](README.md)
