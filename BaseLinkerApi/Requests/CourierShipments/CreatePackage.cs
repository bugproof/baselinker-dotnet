using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// The method allows you to create a shipment in the system of the selected courier.
/// </summary>
public class CreatePackage : IRequest<CreatePackage.Response>
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

        [JsonPropertyName("size_custom")]
        public double SizeCustom { get; set; }
    }
        
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    [JsonPropertyName("courier_code")]
    public string CourierCode { get; set; }

    [JsonPropertyName("account_id")]
    public int? AccountId { get; set; }

    [JsonPropertyName("fields")]
    public List<Field> Fields { get; set; }

    [JsonPropertyName("packages")]
    public List<Package> Packages { get; set; }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("package_id")]
        public int PackageId { get; set; }

        [JsonPropertyName("package_number")]
        public string PackageNumber { get; set; }

        [JsonPropertyName("courier_inner_number")]
        public string CourierInnerNumber { get; set; }
    }
}