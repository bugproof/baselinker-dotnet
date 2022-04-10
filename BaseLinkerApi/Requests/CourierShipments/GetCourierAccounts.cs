using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// The method allows you to retrieve the list of accounts connected to a given courier.
/// </summary>
public class GetCourierAccounts : IRequest<GetCourierAccounts.Response>
{
    /// <summary>
    /// Courier code
    /// </summary>
    [JsonPropertyName("courier_code")]
    public string CourierCode { get; set; }

    public class Account
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("accounts")]
        public List<Account> Accounts { get; set; }
    }
}