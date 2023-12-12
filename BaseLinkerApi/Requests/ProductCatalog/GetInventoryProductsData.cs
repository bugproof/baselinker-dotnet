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
        [JsonPropertyName("ean")]
        public string Ean { get; set; }
            
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

        [JsonPropertyName("links")]
        public Dictionary<string, Link> Links { get; set; }
            
        [JsonPropertyName("variants")]
        public Dictionary<int, Variant> Variants { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("products")]
        public Dictionary<int, Product> Products { get; set; }
    }
}
