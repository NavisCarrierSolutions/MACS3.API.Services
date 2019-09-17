# MACS3 API Services

The MACS3 API Services enable users to perform cloud-based stability-, lashing-, dangerous cargo calculations and condition checks for vessels.

You can easily integrate the services into your digital infrastructure by calling the RESTful APIs, so your application will make HTTP requests and parse the response. By default, the response format is JSON

## Requirements

* Your personal company account
* Your account related API-Key
* Your account/vessel assignment (by IMO-Number)

In order to request an account, please contact [api.macs3@navis.com](mailto:api.macs3@navis.com).

## Quick Start: Explore the services through RESTful APIs

The service documentations are based on the OpenAPI specification (aka Swagger) and can best be explored by using a REST Client like Swagger or Postman.

* Swagger has got the benefit of being a combination of REST Client and built-in "documentation right at your fingertips" - so it's a good point to start.
* Postman is the most-used REST Client worldwide and gives you maximum flexibility and unlimited options. More experienced users may prefer to use Postman as REST Client and use the Swagger documentation just for reference.

Have your API-Key ready and follow our [Swagger](swagger.md) or [Postman](postman.md) guide (Stability) for a quick start.

## Advanced: Integrate the services into your solution

When it comes to integration, you should use Client SDKs to take the RESTful API complexity out of coding as the SDKs provide models and endpoints for each service as reusable packages. 
 
* If your coding platform is C#, you may use the [SDKs](https://www.nuget.org/packages?q=+MACS3.Connected) published by Navis NCVS at nuget.org:  

  MACS3.Connected.SDK.Stability  
  MACS3.Connected.SDK.Lashing  
  MACS3.Connected.SDK.DangerousCargo  
  MACS3.Connected.SDK.ConditionCheck  
  
  Have your API-Key ready and see how to call the services in the [C# Stability Sample](csharp_stability.md), [C# Lashing Sample](csharp_lashing.md), [C# DangerousGoods Sample](csharp_dago.md) and [C# Condition Check Sample](csharp_conditioncheck.md).

* If you are coding on another platform e.g. JavaScript, Java, Objective C, Swift or C++, consider auto-generating the Client SDKs. The service documentations can be used as input by a variety of popular code-generators like [Swagger Codegen](https://swagger.io/tools/swagger-codegen) or [SwaggerHub](https://swagger.io/tools/swaggerhub) to generate Client SDKs. Please check out the documentation of your preferred code-generator for details. 

  The following service documentations are available:
  * https://api.stability.macs3.com
  * https://api.lashing.macs3.com
  * https://api.dago.macs3.com
  * https://api.conditioncheck.macs3.com

  Even when coding on another platform, see how to call the services in the [C# Stability Sample](csharp_stability.md), [C# Lashing Sample](csharp_lashing.md), [C# DangerousGoods Sample](csharp_dago.md) and [C# Condition Check Sample](csharp_conditioncheck.md).

## What's next?

If you wish to stay informed about the latest MACS3 API Service changes, you may subscribe to our <a href="https://releasenotes.api-services.navis-cvs.com" target="_blank">Release-Notes</a>.
