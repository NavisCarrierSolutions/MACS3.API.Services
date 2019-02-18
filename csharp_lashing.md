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
using Macs3.Connected;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = IO.Swagger.Model;

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
                        var parameters = new Model.LashingParameters(new Model.DynamicParameters(
                            gm: 5,
                            draft: 10,
                            vesselSpeed: 15.0,
                            windSpeed: 40.0));

                        parameters.Containers = new List<Model.ContainerParameter>
                        {
                            new Model.ContainerParameter(id:1, containerId:"AAAU1234568", typeIsoCode:"42G0", grossWeight:10.1, position:"020206", relativeVcg:0.50, height:2.591, length:12.192, width:2.438),
                            new Model.ContainerParameter(id:2, containerId:"AAAU1234569", typeIsoCode:"42G0", grossWeight:10.1, position:"020282", relativeVcg:0.50, height:2.591, length:12.192, width:2.438),
                        };

                        parameters.Calculate = new Model.WhatToCalculateParameterLashing
                        {
                            LoadableWeights = true,
                            PlacedLashBars = true
                        };

                        var json = JsonConvert.SerializeObject(parameters);
                        var result = await apiClient.PerformLashCalculationsAsync(imoNumber, parameters);
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

If you run the above given sample and your request is valid (http-status-code equals 200), you may continue and inspect the details in ```result``` according to the technical documentation at https://api.stability.macs3.com.

[back](README.md)
