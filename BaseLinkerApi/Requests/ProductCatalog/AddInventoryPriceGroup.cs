using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows to create a price group in BaseLinker storage. Providing a price group ID will update the existing price group. Such price groups may be later assigned in addInventory method.
/// </summary>
public class AddInventoryPriceGroup : IRequest<AddInventoryPriceGroup.Response>
{
    /// <summary>
    /// Price group identifier
    /// </summary>
    [JsonPropertyName("price_group_id")]
    public int? PriceGroupId { get; set; }
            
    /// <summary>
    /// Name of the price group
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Price group description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 3-letter currency symbol e.g. PLN, EUR
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// The ID number of added or updated price group.
        /// </summary>
        [JsonPropertyName("price_group_id")]
        public int PriceGroupId { get; set; }
    }
}