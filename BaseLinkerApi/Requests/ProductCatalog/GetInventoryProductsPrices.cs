using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows to retrieve the gross prices of products from BaseLinker catalogues.
/// </summary>
public class GetInventoryProductsPrices : IRequest<GetInventoryProductsPrices.Response>
{
    /// <summary>
    /// Catalog ID. The list of identifiers can be retrieved using the method getInventories.
    /// </summary>
    [JsonPropertyName("inventory_id")]
    public int InventoryId { get; set; }
        
    /// <summary>
    /// (optional) Results paging (1000 products per page for BaseLinker warehouse)
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    public class ProductPrices
    {
        /// <summary>
        /// A list where the key is the price group identifier and the value is the gross price set for that price group.
        /// The list of price groups can be retrieved using the getInventoryPriceGroups method.
        /// </summary>
        [JsonPropertyName("prices")]
        public Dictionary<int, decimal> Prices { get; set; }
            
        /// <summary>
        /// A list containing variants stocks, where the key is the variant ID. The value is a list where a key is a warehouse ID and value is a stock in this warehouse.
        /// </summary>
        [JsonPropertyName("variants")]
        public Dictionary<int, double> Variants { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("products")]
        public Dictionary<int, ProductPrices> ProductsPrices { get; set; }
    }
}