using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// The method allows you to retrieve additional courier services, which depend on other shipment settings.
/// Used only for X-press and BrokerSystem couriers. Not applicable to other couriers whose forms have fixed options.
/// The details of the package should be sent with the method (the format as in createPackage) in order to receive a list of additional services
/// </summary>
public class GetCourierServices : IRequest<GetCourierServices.Response>
{
    public class Field
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Package
    {
        [JsonPropertyName("length")]
        public double Length { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("width")]
        public double Width { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }
    }
        
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    [JsonPropertyName("courier_code")]
    public string CourierCode { get; set; }

    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }

    [JsonPropertyName("fields")]
    public List<Field> Fields { get; set; }

    [JsonPropertyName("packages")]
    public List<Package> Packages { get; set; }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("services")]
        public Dictionary<string, string> Services { get; set; }
    }
}