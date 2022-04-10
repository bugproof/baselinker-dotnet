using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve a list of manufacturers for a BaseLinker catalog.
/// </summary>
public class GetInventoryManufacturers : IRequest<GetInventoryManufacturers.Response>
{
    public class Manufacturer
    {
        [JsonPropertyName("manufacturer_id")]
        public int ManufacturerId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("manufacturers")]
        public List<Manufacturer> Manufacturers { get; set; }
    }
}