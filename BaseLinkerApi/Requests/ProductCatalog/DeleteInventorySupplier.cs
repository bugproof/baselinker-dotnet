using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to remove a supplier from BaseLinker storage.
/// </summary>
public class DeleteInventorySupplier : IRequest
{
    /// <summary>
    /// Supplier identifier
    /// </summary>
    [JsonPropertyName("supplier_id")]
    public int SupplierId { get; set; }
}
