using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve stock data of products from BaseLinker catalogs
/// </summary>
public class GetInventoryProductsStock : IRequest<GetInventoryProductsStock.Response>
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

    public class ProductStock
    {
        /// <summary>
        /// A list where the key is the warehouse ID and the value is a stock for this warehouse. Warehouse ID should have this format: "[type:bl|shop|warehouse]_[id:int]" (np. "bl_123").
        /// The list of warehouse IDs can be retrieved with getInventoryWarehouses method.
        /// </summary>
        [JsonPropertyName("stock")]
        public Dictionary<string, int> Stock { get; set; }
            
        /// <summary>
        /// A list containing variants stocks, where the key is the variant ID. The value is a list where a key is a warehouse ID and value is a stock in this warehouse.
        /// </summary>
        [JsonPropertyName("variants")]
        public Dictionary<string, int> Variants { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("products")]
        public Dictionary<int, ProductStock> Products { get; set; }
    }
}