using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to remove the price group from BaseLinker storage.
/// </summary>
public class DeleteInventoryPriceGroup : IRequest
{
    /// <summary>
    /// Price group identifier
    /// </summary>
    [JsonPropertyName("price_group_id")]
    public int PriceGroupId { get; set; }
}