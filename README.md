# MACS3.Connected
This documentation illustrates the usage of the different MACS3.Connected SDK:

MACS3.Connected.Stablity.SDK
MACS3.Connected.Lashing.SDK
MACS3.Connected.DangerousCargo.SDK

## Stability calculation
This snippet explains how to perform a stability calculation in C# 7.1.

Install the MACS3.Connected Stability SDK from nuget.org:
```
Install-Package nn
```

```
using Macs3.Connected.Stability.SDK;
using Model = IO.Swagger.Model;

namespace Macs3.Connected.StabilityTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var apiClient = await API2.CreateClientAsync(new ApiKeyProvider { ApiKey = "YOUR-API-KEY" }))
            {
                try
                {
                    Model.CalculationsParameter parameter;
                    Model.CalculationsResult result;

                    parameter = new Model.CalculationsParameter();
                    result = await apiClient.CalculateStabilityAsync("YOUR-IMO-NUMBER", parameter);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
```

## Lashing calculation
This snippet explains how to perform a lashing calculation in C#.

Install the MACS3.Connected Lashing SDK from nuget.org:
```
Install-Package nn
```

```
using Macs3.Connected.Stability.SDK;
using Model = IO.Swagger.Model;

namespace Macs3.Connected.LashingTest
{
    ...
    using (var apiClient = await API2.CreateClientAsync(new ApiKeyProvider { ApiKey = "YOUR-API-KEY" }))
    {
    }
    ...
}
```

## DangerousCargo calculation
This snippet explains how to perform a dangerous-cargo calculation in C#.

Install the MACS3.Connected DangerousCargo SDK from nuget.org:
```
Install-Package nn
```

```
using Macs3.Connected.Stability.SDK;
using Model = IO.Swagger.Model;

namespace Macs3.Connected.DangerousCargoTest
{
    ...
    using (var apiClient = await API2.CreateClientAsync(new ApiKeyProvider { ApiKey = "YOUR-API-KEY" }))
    {
    }
    ...
}
```
