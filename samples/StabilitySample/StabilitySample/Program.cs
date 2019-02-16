using Macs3.Connected;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = IO.Swagger.Model;

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

                        var userSettings = new Model.SettingsParameter { };
                        parameter.Settings = userSettings;

                        var json = JsonConvert.SerializeObject(parameter);
                        var result = await apiClient.CalculateStabilityAsync(imoNumber, parameter);
                    }
                    catch (ApiException e)
                    {
                    }
                }
            }).Wait();
        }
    }
}
