using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to add a manufacturer to the BaseLinker catalog. Adding a manufacturer with the same identifier again, updates the previously saved manufacturer
/// </summary>
public class AddInventoryManufacturer : IRequest<AddInventoryManufacturer.Response>
{
    /// <summary>
    /// Manufacturer ID provided in case of an update. Should be blank when creating a new manufacturer.
    /// </summary>
    [JsonPropertyName("manufacturer_id")]
    public int? ManufacturerId { get; set; }
            
    /// <summary>
    /// Manufacturer name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// ID of a created or updated manufacturer
        /// </summary>
        [JsonPropertyName("manufacturer_id")]
        public int ManufacturerId { get; set; }
    }
}