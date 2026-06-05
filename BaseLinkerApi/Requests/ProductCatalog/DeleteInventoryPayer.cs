using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to remove a payer from BaseLinker storage.
/// </summary>
public class DeleteInventoryPayer : IRequest
{
    /// <summary>
    /// Payer identifier
    /// </summary>
    [JsonPropertyName("payer_id")]
    public int PayerId { get; set; }
}
