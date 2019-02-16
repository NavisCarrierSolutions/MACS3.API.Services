### Swagger: Explore the stability service

## 1. Open the service documentation

Use your webbrowser to navigate to https://api.stability.macs3.com 

![Login](images/sw_stability.png)

## 2. Authorize with your company API-Key

NOTE: Prepend your API-Key with "ApkiKey<space>" and hit [Authorize].

![Login](images/sw_stability_authorize.png)

## 3. Select an endpoint to test

Navigate to [POST]/ships/{imonumber}/stability.  
Hit [Try it out]

![Login](images/sw_stability_try.png)

## 4. Specify details for the request

Fill in the imoNumber of the vessel.  
Fill in the calculationsParameter in JSON-Notation. When first try out the services, this is the tricky part and requires an  intense inspection of the documentation. Please the following JSON-Snippet.   
Scroll down and Hit [Execute].  

![Login](images/sw_stability_execute.png)

## 5. Check the response

If everything is fine, the response is usually a http-status-code of 200.  
Consult the built-in documentation to understand the response.  

![Login](images/sw_stability_response.png)

[back](README.md)
