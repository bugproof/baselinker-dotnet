using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to remove the product from BaseLinker catalog.
/// </summary>
public class DeleteInventoryProduct : IRequest
{
    /// <summary>
    /// BaseLinker catalogue product identifier
    /// </summary>
    [JsonPropertyName("product_id")]
    public int ProductId { get; set; }
}