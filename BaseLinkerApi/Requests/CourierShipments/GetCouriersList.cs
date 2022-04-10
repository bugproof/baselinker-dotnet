using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// The method allows you to retrieve a list of available couriers.
/// </summary>
public class GetCouriersList : IRequest<GetCouriersList.Response>
{
    public class Courier
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("couriers")]
        public List<Courier> Couriers { get; set; }
    }
}