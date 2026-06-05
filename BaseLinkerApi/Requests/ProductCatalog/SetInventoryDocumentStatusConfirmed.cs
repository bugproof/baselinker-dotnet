using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to confirm an inventory document, which will affect the stock levels in the warehouse.
/// </summary>
public class SetInventoryDocumentStatusConfirmed : IRequest
{
    /// <summary>
    /// Document identifier
    /// </summary>
    [JsonPropertyName("document_id")]
    public int DocumentId { get; set; }
}
