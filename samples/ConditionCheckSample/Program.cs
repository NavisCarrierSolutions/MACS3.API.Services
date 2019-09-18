using MACS3.Connected.SDK.ConditionCheck.Model;
using MACS3.Connected.SDK.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;


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

                        // Specify settings for the call
                        condition.Settings = new ConditionCheckSettingsParameter
                        {

                        };

                        // Specify which check to carry out
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
                                Position = "020086", // 020084 is lowest
                                TypeIsoCode = "45G0"
                            }
                        };

                        // View the payload e.g. for Swagger/Postman
                        var json = JsonConvert.SerializeObject(condition);

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
}
