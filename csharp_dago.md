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
using MACS3.Connected.SDK.Core;
using MACS3.Connected.SDK.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MACS3.Connected.DangerousGoodsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var provider = new ApiKeyProvider { ApiKey = "<YOUR-API-KEY>" };
                
                using (var apiClient = await MACS3.Connected.SDK.DangerousGoods.API2.CreateClientAsync(provider))
                {
                    try
                    {
                        DaGoCheckParameters parameter = new DaGoCheckParameters();

                        parameter.Settings = new DaGoSettingsParameter(
                            amendmentNumber: 38,
                            checkForSunlight: true,
                            stowKeepCoolCargoAwayFromReefers: true,
                            stowKeepCoolCargoAwayFromSun: true);

                        parameter.Containers = new List<DaGoContainerParameter>
                        {
                            new DaGoContainerParameter
                            (
                                id: "11",
                                containerId: "NCVS1234568",
                                typeIsoCode: "42G0",
                                grossWeight: 10.1,
                                position: "020206",
                                relativeVcg: 0.50,
                                height: 2.591,
                                length: 12.192,
                                width: 2.438,
                                openTop: false,
                                liveReefer: false,
                                empty: false,
                                doorOrientationAft: false,
                                foodStuff: false,
                                sunExposed: false,
                                dangerousGoods: new List<DangerousGoodParameter>
                                {
                                    new DangerousGoodParameter
                                    (
                                        un: 1234,
                                        _class: "3",
                                        packingGroup: 2,
                                        subLabel: "",
                                        subLabel2: "",
                                        stowageCategory: "E",
                                        technicalName: "",
                                        flashpoint: -28,
                                        limitedQuantity: false,
                                        exceptedQuantity: false,
                                        marinePollutant: false,
                                        caa: false,
                                        segregationGroup: ""
                                    )
                                }
                            ),
                            new DaGoContainerParameter
                            (
                                id: "12",
                                containerId: "NCVS1234569",
                                typeIsoCode: "42G0",
                                grossWeight: 10.1,
                                position: "020208",
                                relativeVcg: 0.50,
                                height: 2.591,
                                length: 12.192,
                                width: 2.438,
                                openTop: false,
                                liveReefer: false,
                                empty: false,
                                doorOrientationAft: false,
                                setPoint: 0,
                                foodStuff: false,
                                sunExposed: false,
                                dangerousGoods: new List<DangerousGoodParameter>
                                {
                                    new DangerousGoodParameter
                                    (
                                        un: 4,
                                        _class: "1.1D",
                                        packingGroup: 1,
                                        subLabel: "",
                                        subLabel2: "",
                                        stowageCategory: "4",
                                        technicalName: "",
                                        limitedQuantity: false,
                                        exceptedQuantity: false,
                                        marinePollutant: false,
                                        caa: false,
                                        segregationGroup: ""
                                    )
                                }
                            )
                        };

                        parameter.ContainerToCheck = new List<ContainerIdentifier>
                        {
                            new ContainerIdentifier(id: "11", containerId: "NCVS1234568", position: "020206")
                        };

                        DaGoCheckResult result = await apiClient.PerformDangerousGoodsCheckAsync(YOUR-IMO-NUMBER, parameter);
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

If you run the above given sample and your request is valid (http-status-code equals 200), you may continue and inspect the details in ```result``` according to the technical documentation at https://api.dago.macs3.com.

[back](README.md)
