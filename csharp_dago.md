# A dead simple DangerousGoods Calculation sample
This sampe shows how to quickly perform a cloudbased calculation using Microsoft Visual Studio, C# and MACS3.Connected SDKs. MACS3.Connected SDK packages can be installed into any .NET project, provided that the package supports the same target framework as the project.

## 1. Create a project
* Open Visual Studio
* Create a Console App (C#)

## 2. Add the MACS3.Connected DangerousGoods SDK from nuget.org
* In Visual Studio select Tools > NuGet Package Manager > Package Manager Console menu command
* Once the console opens, check that the Default project drop-down list shows the project into which you want to install the package.
* Enter the command ```Install-Package MACS3.Connected.SDK.DangerousGoods```

## 3. Sample code

The full sample can be downloaded [here](samples)

```
using System.Collections.Generic;
using System.Threading.Tasks;
using MACS3.Connected.SDK.Core;
using Model = MACS3.Connected.SDK.Model;

namespace DangerousGoodsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var apiKey = "<YOUR-API-KEY>";
                var imoNumber = 1234567;
                var provider = new ApiKeyProvider {ApiKey = apiKey};

                using (var apiClient = await MACS3.Connected.SDK.DangerousGoods.API2.CreateClientAsync(provider))
                {
                    try
                    {
                        var parameter = new Model.DaGoCheckParameters();

                        // Specify some settings for the calculation
                        parameter.Settings = new Model.DaGoSettingsParameter
                        {
                            AmendmentNumber = 38,
                            CheckForSunlight = true,
                            StowKeepCoolCargoAwayFromReefers = true,
                            StowKeepCoolCargoAwayFromSun = true
                        };

                        // Add two containers to the load - class 3 and 1.1d
                        parameter.Containers = new List<Model.DaGoContainerParameter>
                        {
                            new Model.DaGoContainerParameter
                            {
                                Id= "11",
                                ContainerId = "NCVS1234568",
                                TypeIsoCode = "42G0",
                                GrossWeight = 10.1,
                                Position = "020206",
                                RelativeVcg = 0.50,
                                Height = 2.591,
                                Length = 12.192,
                                Width = 2.438,
                                OpenTop = false,
                                LiveReefer = false,
                                Empty = false,
                                DoorOrientationAft = false,
                                FoodStuff = false,
                                SunExposed = false,
                                DangerousGoods = new List<Model.DangerousGoodParameter>
                                {
                                    new Model.DangerousGoodParameter
                                    {
                                        Un = 1234,
                                        Class = "3",
                                        PackingGroup = 2,
                                        SubLabel = "",
                                        SubLabel2 = "",
                                        StowageCategory = "E",
                                        TechnicalName = "",
                                        Flashpoint = -28,
                                        LimitedQuantity = false,
                                        ExceptedQuantity = false,
                                        MarinePollutant = false,
                                        Caa = false,
                                        SegregationGroup = ""
                                    }
                                }
                            },
                            new Model.DaGoContainerParameter
                            {
                                Id = "12",
                                ContainerId = "NCVS1234569",
                                TypeIsoCode = "42G0",
                                GrossWeight = 10.1,
                                Position = "020208",
                                RelativeVcg = 0.50,
                                Height = 2.591,
                                Length = 12.192,
                                Width = 2.438,
                                OpenTop = false,
                                LiveReefer = false,
                                Empty = false,
                                DoorOrientationAft = false,
                                SetPoint = 0,
                                FoodStuff = false,
                                SunExposed = false,
                                DangerousGoods = new List<Model.DangerousGoodParameter>
                                {
                                    new Model.DangerousGoodParameter
                                    {
                                        Un = 4,
                                        Class = "1.1D",
                                        PackingGroup = 1,
                                        SubLabel = "",
                                        SubLabel2 = "",
                                        StowageCategory = "4",
                                        TechnicalName = "",
                                        LimitedQuantity = false,
                                        ExceptedQuantity = false,
                                        MarinePollutant = false,
                                        Caa = false,
                                        SegregationGroup = ""
                                    }
                                }
                            }
                        };

                        // Add a container to be checked
                        parameter.ContainerToCheck = new List<Model.ContainerIdentifier>
                        {
                            new Model.ContainerIdentifier
                            {
                                Id = "11", ContainerId = "NCVS1234568", Position = "020206"
                            }
                        };

                        // View the payload e.g. for Swagger/Postman
                        //var json = JsonConvert.SerializeObject(parameters);

                        // Call the DG Calculation
                        var result = await apiClient.PerformDangerousGoodsCheckAsync(imoNumber, parameter);

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

If you run the above given sample and your request is valid (http-status-code equals 200), you may continue and inspect the details in ```result``` according to the technical documentation at https://api.dago.macs3.com.

[back](README.md)
