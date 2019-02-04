# MACS3.Connected
This documentation illustrates the usage of the different MACS3.Connected REST API
## Basic usage
This example explains how to perform a stability-calculation in C#.
Install the package from nuget.org:

```
Install-Package nn
```

```
using Macs3.Connected.Stability.SDK;
using Model = IO.Swagger.Model;

namespace Macs3.Connected.StabilityTest
{
    using (var apiClient = await API2.CreateClientAsync(new ApiKeyProvider { ApiKey = "YOUR-API-KEY" }))
    {
        try
        {
            Model.CalculationsParameter parameter;
            Model.CalculationsResult result;

            parameter = new Model.CalculationsParameter();
            result = await apiClient.CalculateStabilityAsync(imoNumber, parameter);
        }
        catch (Exception)
        {
        }
    }
}
```
