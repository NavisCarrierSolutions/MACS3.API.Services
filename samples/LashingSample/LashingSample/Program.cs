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
