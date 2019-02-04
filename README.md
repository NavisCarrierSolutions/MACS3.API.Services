# MACS3.Connected
This documentation illustrates the usage of the different MACS3.Connected SDK in C# 7.1:

* MACS3.Connected.Stability.SDK\
* MACS3.Connected.Lashing.SDK\
* MACS3.Connected.DangerousCargo.SDK

## Stability calculation
This snippet explains how to perform a stability calculation

### Create a project
NuGet packages can be installed into any .NET project, provided that the package supports the same target framework as the project.

### Add the MACS3.Connected Stability SDK from nuget.org:
1. In Visual Studio select Tools > NuGet Package Manager > Package Manager Console menu command\
2. Once the console opens, check that the Default project drop-down list shows the project into which you want to install the package.\
3. Enter the command ```Install-Package nn```

### Use SDK in the app:
```
using Macs3.Connected.Stability.SDK;
using Model = IO.Swagger.Model;

namespace Macs3.Connected.StabilityTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var provider = new ApiKeyProvider { ApiKey = "YOUR-API-KEY" };
            
            using (var apiClient = await Macs3.Connected.Stability.SDK.API2.CreateClientAsync(provider))
            {
                try
                {
                    Model.CalculationsParameter parameter;
                    Model.CalculationsResult result;

                    parameter = new Model.CalculationsParameter();
                    result = await apiClient.CalculateStabilityAsync(YOUR-IMO-NUMBER, parameter);
                }
                catch (ApiException)
                {
                }
            }
        }
    }
}
```

## Lashing calculation
This snippet explains how to perform a lashing calculation in C# 7.1.

Install the MACS3.Connected Lashing SDK from nuget.org:
```
Install-Package nn
```

Create an empty console app project:
```
using Macs3.Connected.Lashing.SDK;
using Model = IO.Swagger.Model;

namespace Macs3.Connected.LashingTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var provider = new ApiKeyProvider { ApiKey = "YOUR-API-KEY" };
            
            using (var apiClient = await Macs3.Connected.Lashing.SDK.API2.CreateClientAsync(provider))
            {
            }
        }
    }
}
```

## DangerousCargo calculation
This snippet explains how to perform a dangerous-cargo calculation in C# 7.1.

Install the MACS3.Connected DangerousCargo SDK from nuget.org:
```
Install-Package nn
```

Create an empty console app project:
```
using Macs3.Connected.DangerousCargo.SDK;
using Model = IO.Swagger.Model;

namespace Macs3.Connected.DangerousCargoTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var provider = new ApiKeyProvider { ApiKey = "YOUR-API-KEY" };
            
            using (var apiClient = await Macs3.Connected.DangerousCargo.SDK.API2.CreateClientAsync())
            {
            }
        }
    }
}
```
