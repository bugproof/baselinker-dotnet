using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to run personal trigger for products automatic actions.
/// </summary>
public class RunProductMacroTrigger : IRequest<ResponseBase>
{
    /// <summary>
    /// Product identifier from BaseLinker product manager.
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; }
    
    /// <summary>
    /// Identifier of personal trigger from products automatic actions.
    /// </summary>
    [JsonPropertyName("trigger_id")]
    public string TriggerId { get; set; }
}