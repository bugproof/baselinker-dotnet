using System;
using System.Net.Http;
using BaseLinkerApi;
using Requests = BaseLinkerApi.Requests;

// TODO: it seems like by default only obsolete api works all methods from ProductCatalog are marked as BETA and return an error 
// ERROR_METHOD - Method available only for accounts with unlocked new BaseLinker storage module. Check products list in old BaseLinker storage module for more information.
// unless you opt-in

using var httpClient = new HttpClient();
var baseLinkerClient = new BaseLinkerApiClient(httpClient, "3001646-3007387-D7KZKSX8A2JFJEX41KG9YNBCQEPLYBHKRVSNM4QC0DWSN29226CZVVDSGR6A5WR6");
// baseLinkerClient.ThrowExceptions = false; // Set this to false if you want to check success status manually, error-prone. If you forget to check you will get null reference exceptions.
try
{
    var response = await baseLinkerClient.Send(new Requests.CourierShipments.GetCouriersList());
    foreach (var courier in response.Couriers)
    {
        Console.WriteLine(courier.Code);
    }
}
catch (BaseLinkerException baseLinkerException)
{
    Console.WriteLine($"Error! {baseLinkerException.ErrorCode} - {baseLinkerException.ErrorMessage}");
}