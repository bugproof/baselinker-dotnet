using System;
using System.Net.Http;
using BaseLinkerApi;
using Requests = BaseLinkerApi.Requests;

// TODO: it seems like by default only obsolete api works all methods from ProductCatalog are marked as BETA and return an error 
// ERROR_METHOD - Method available only for accounts with unlocked new BaseLinker storage module. Check products list in old BaseLinker storage module for more information.
// unless you opt-in

using var httpClient = new HttpClient();
var baseLinkerClient = new BaseLinkerApiClient(httpClient, "3001646-3007387-D7KZKSX8A2JFJEX41KG9YNBCQEPLYBHKRVSNM4QC0DWSN29226CZVVDSGR6A5WR6");
var response = await baseLinkerClient.Send(new Requests.CourierShipments.GetCouriersList());
if (response.IsSuccessStatus)
{
    foreach (var courier in response.Couriers)
    {
        Console.WriteLine(courier.Code);
    }
}
else
{
    Console.WriteLine($"Error! {response.ErrorCode} - {response.ErrorMessage}");
}