using System;
using System.Net.Http;
using BaseLinkerApi;
using Requests = BaseLinkerApi.Requests;

var token = Environment.GetEnvironmentVariable("BASELINKER_TOKEN");
if (string.IsNullOrWhiteSpace(token))
{
    Console.WriteLine("BASELINKER_TOKEN environment variable not set or incorrect");
    return;
}

using var httpClient = new HttpClient();
var baseLinkerClient = new BaseLinkerApiClient(httpClient, token)
{
    ThrowExceptions =
        true, // Set this to false if you want to check success status manually, error-prone. If you forget to check you will get null reference exceptions.
};
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