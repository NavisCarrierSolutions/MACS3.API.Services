# A dead simple Condition Check sample
This sampe shows how to quickly perform a cloudbased condition check using Microsoft Visual Studio, C# and MACS3.Connected SDKs. MACS3.Connected SDK packages can be installed into any .NET project, provided that the package supports the same target framework as the project.

## 1. Create a project
* Open Visual Studio
* Create a Console App (C#)

## 2. Add the MACS3.Connected Condition Check SDK from nuget.org
* In Visual Studio select Tools > NuGet Package Manager > Package Manager Console menu command
* Once the console opens, check that the Default project drop-down list shows the project into which you want to install the package.
* Enter the command ```Install-Package MACS3.Connected.SDK.Stability```

## 3. Sample code

The full sample can be downloaded [here](samples)

```
using System.Collections.Generic;
using System.Threading.Tasks;
using MACS3.Connected.SDK.ConditionCheck.Model;
using MACS3.Connected.SDK.Core;

namespace ConditionCheckSample
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

                using (var apiClient = await MACS3.Connected.SDK.ConditionCheck.API2.CreateClientAsync(provider))
                {
                    try
                    {
                        var condition = new ConditionCheckParameter();

                        condition.Settings = new ConditionCheckSettingsParameter
                        {

                        };

                        // Specify what you want to be calculated
                        condition.WhatToCheck = new ConditionCheckWhatToCalculateParameter()
                        {
                            FlyingMixStowageCheck = true
                        };

                        // Add one container to the condition
                        condition.Containers = new List<ContainerParameter>()
                        {
                            new ContainerParameter()
                            {
                                Id = "1",
                                ContainerId = "ABCD1234567",
                                Position = "020086", // 020084 is lowest tier
                                TypeIsoCode = "45G0"
                            }
                        };

                        // View the payload e.g. for Swagger/Postman
                        // var json = JsonConvert.SerializeObject(condition);

                        var result = await apiClient.ConditionCheckAsync(imoNumber, "", condition);

                        // Inspect result for further processing
                    }
                    catch (ApiException)
                    {
                    }
                }
            }).Wait();
        }
    }
```

In the above given sample, you just have to replace "YOUR-API-KEY" and YOUR-IMO-NUMBER with your specific data.

If you run the above given sample and your request is valid (http-status-code equals 200), you may continue and inspect the details in ```result``` according to the technical documentation at https://api.conditioncheck.macs3.com.

[back](README.md)
