using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve detailed data for selected products from the BaseLinker catalogue.
/// </summary>
public class GetInventoryProductsData : IRequest<GetInventoryProductsData.Response>
{
    /// <summary>
    /// Catalog ID. The list of identifiers can be retrieved using the method getInventories.
    /// </summary>
    [JsonPropertyName("inventory_id")]
    public int InventoryId { get; set; }

    /// <summary>
    /// An array of product ID numbers to download
    /// </summary>
    [JsonPropertyName("products")]
    public List<int> Products { get; set; }

    /// <summary>
    /// (optional) Include ERP units in the response. Only available for inventories with purchase cost calculations system different than AVCO.
    /// </summary>
    [JsonPropertyName("include_erp_units")]
    public bool? IncludeErpUnits { get; set; }

    /// <summary>
    /// (optional) Include additional EANs in response. User can set additional EANs for product, to work with products cases (4-pack etc.) or different regional codes for the same product.
    /// </summary>
    [JsonPropertyName("include_additional_eans")]
    public bool? IncludeAdditionalEans { get; set; }

    public class AdditionalEan
    {
        /// <summary>
        /// EAN number
        /// </summary>
        [JsonPropertyName("ean")]
        public string Ean { get; set; }

        /// <summary>
        /// Quantity of product with given EAN number
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }

    public class StockErpUnit
    {
        /// <summary>
        /// Quantity of given ERP unit
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Purchase cost of given ERP unit
        /// </summary>
        [JsonPropertyName("purchase_cost")]
        public double PurchaseCost { get; set; }

        /// <summary>
        /// Expiry date of given ERP unit
        /// </summary>
        [JsonPropertyName("expiry_date")]
        public string ExpiryDate { get; set; }
    }

    public class Link
    {
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }
            
        [JsonPropertyName("variant_id")]
        public int VariantId { get; set; }
    }

    public class Variant
    {
        [JsonPropertyName("ean")]
        public string Ean { get; set; }

        [JsonPropertyName("asin")]
        public string Asin { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }
            
        [JsonPropertyName("name")]
        public string Name { get; set; }
            
        [JsonPropertyName("prices")]
        public Dictionary<int, decimal> Prices { get; set; }
            
        [JsonPropertyName("stock")]
        public Dictionary<string, int> Stock { get; set; }
            
        [JsonPropertyName("locations")]
        public Dictionary<string, string> Locations { get; set; }
    }
    
    public class Product
    {
        /// <summary>
        /// Product parent ID. Returns 0 for main products, or the main product ID for variants.
        /// </summary>
        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }

        [JsonPropertyName("ean")]
        public string Ean { get; set; }

        /// <summary>
        /// A list containing additional EAN numbers (returned only if include_additional_eans is set to true).
        /// </summary>
        [JsonPropertyName("ean_additional")]
        public List<AdditionalEan> EanAdditional { get; set; }

        /// <summary>
        /// Product ASIN number (primary ASIN).
        /// </summary>
        [JsonPropertyName("asin")]
        public string Asin { get; set; }

        /// <summary>
        /// A list of product tags.
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("tax_rate")]
        public double TaxRate { get; set; }
            
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
            
        [JsonPropertyName("height")]
        public double Height { get; set; }
            
        [JsonPropertyName("width")]
        public double Width { get; set; }
            
        [JsonPropertyName("length")]
        public double Length { get; set; }

        [JsonPropertyName("star")]
        public double Star { get; set; }

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
            
        [JsonPropertyName("manufacturer_id")]
        public int ManufacturerId { get; set; }
            
        [JsonPropertyName("prices")]
        public Dictionary<int, decimal> Prices { get; set; }
            
        [JsonPropertyName("stock")]
        public Dictionary<string, int> Stock { get; set; }
            
        [JsonPropertyName("locations")]
        public Dictionary<string, string> Locations { get; set; }
            
        [JsonPropertyName("text_fields")] 
        public Dictionary<string, object> TextFields { get; set; }

        [JsonPropertyName("average_cost")]
        public decimal AverageCost { get; set; }
        
        [JsonPropertyName("average_landed_cost")]
        public decimal AverageLandedCost { get; set; }

        [JsonPropertyName("images")]
        public Dictionary<string, string> Images { get; set; }

        /// <summary>
        /// A list of product videos where the key is the 1-based video position (1-6) and the value is the video URL.
        /// </summary>
        [JsonPropertyName("videos")]
        public Dictionary<int, string> Videos { get; set; }

        [JsonPropertyName("links")]
        public Dictionary<string, Link> Links { get; set; }
            
        [JsonPropertyName("variants")]
        public Dictionary<int, Variant> Variants { get; set; }

        /// <summary>
        /// A list containing products stock erp units, where the key is the warehouse ID and value is a list of units in given warehouse.
        /// </summary>
        [JsonPropertyName("stock_erp_units")]
        public Dictionary<string, List<StockErpUnit>> StockErpUnits { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("products")]
        public Dictionary<int, Product> Products { get; set; }
    }
}
