using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to remove manufacturer from BaseLinker catalog
/// </summary>
public class DeleteInventoryManufacturer : IRequest
{
    /// <summary>
    /// The ID of the manufacturer removed from BaseLinker warehouse.
    /// </summary>
    [JsonPropertyName("manufacturer_id")]
    public int ManufacturerId { get; set; }
}