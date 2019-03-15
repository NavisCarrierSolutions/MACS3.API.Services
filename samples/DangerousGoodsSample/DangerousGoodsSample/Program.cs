using MACS3.Connected.SDK.Core;
using MACS3.Connected.SDK.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                        DaGoCheckResult result = await apiClient.PerformDangerousGoodsCheckAsync(imoNumber, parameter);
                    }
                    catch (ApiException e)
                    {
                    }
                }
            }).Wait();
        }
    }
}
