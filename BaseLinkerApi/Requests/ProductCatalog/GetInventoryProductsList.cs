using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

public class GetInventoryProductsList : IRequest<GetInventoryProductsList.Response>
{
    /// <summary>
    /// Catalog ID. The list of identifiers can be retrieved using the method getInventories.
    /// </summary>
    [JsonPropertyName("inventory_id")]
    public int InventoryId { get; set; }

    /// <summary>
    /// (optional) limiting results to a specific product id
    /// </summary>
    [JsonPropertyName("filter_id")]
    public int? FilterId { get; set; }
        
    /// <summary>
    /// (optional) Retrieving products from a specific category (optional)
    /// </summary>
    [JsonPropertyName("filter_category_id")]
    public int? FilterCategoryId { get; set; }
        
    /// <summary>
    /// (optional) limiting results to a specific ean
    /// </summary>
    [JsonPropertyName("filter_ean")]
    public string? FilterEan { get; set; }
        
    /// <summary>
    /// (optional) limiting the results to a specific SKU (stock keeping number)
    /// </summary>
    [JsonPropertyName("filter_sku")]
    public string? FilterSku { get; set; }
        
    /// <summary>
    /// (optional) item name filter (part of the searched name or an empty field)
    /// </summary>
    [JsonPropertyName("filter_name")]
    public string? FilterName { get; set; }
        
    /// <summary>
    /// (optional) minimum price limit (not displaying products with lower price)
    /// </summary>
    [JsonPropertyName("filter_price_from")]
    public double? FilterPriceFrom { get; set; }
        
    /// <summary>
    /// (optional) maximum price limit
    /// </summary>
    [JsonPropertyName("filter_price_to")]
    public double? FilterPriceTo { get; set; }
        
    /// <summary>
    /// (optional) minimum quantity limit
    /// </summary>
    [JsonPropertyName("filter_stock_from")]
    public int? FilterStockFrom { get; set; }
        
    /// <summary>
    /// (optional) maximum quantity limit
    /// </summary>
    [JsonPropertyName("filter_stock_to")]
    public int? FilterStockTo { get; set; }
        
    /// <summary>
    /// (optional) Results paging (1000 products per page for BaseLinker warehouse)
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }
        
    /// <summary>
    /// (optional) the value for sorting the product list. Possible values: "id [ASC|DESC]", "name [ASC|DESC]", "quantity [ASC|DESC]", "price [ASC|DESC]"
    /// </summary>
    [JsonPropertyName("filter_sort")]
    public string? FilterSort { get; set; }

    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("ean")]
        public string Ean { get; set; }
            
        [JsonPropertyName("sku")]
        public string Sku { get; set; }
            
        [JsonPropertyName("name")]
        public string Name { get; set; }
            
        [JsonPropertyName("prices")]
        public Dictionary<int, decimal> Prices { get; set; }
            
        [JsonPropertyName("stock")]
        public Dictionary<string, int> Stock { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("products")]
        public Dictionary<int, Product> Products { get; set; }
    }
}