using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog
{
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
            public Dictionary<string, int> Locations { get; set; }
        }
        
        public class Product
        {
            [JsonPropertyName("ean")]
            public string Ean { get; set; }
            
            [JsonPropertyName("sku")]
            public string Sku { get; set; }
            
            [JsonPropertyName("tax_rate")]
            public int TaxRate { get; set; }
            
            [JsonPropertyName("weight")]
            public float Weight { get; set; }
            
            [JsonPropertyName("height")]
            public float Height { get; set; }
            
            [JsonPropertyName("width")]
            public float Width { get; set; }
            
            [JsonPropertyName("length")]
            public float Length { get; set; }

            [JsonPropertyName("star")]
            public float Star { get; set; }

            [JsonPropertyName("category_id")]
            public int CategoryId { get; set; }
            
            [JsonPropertyName("manufacturer_id")]
            public int ManufacturerId { get; set; }
            
            [JsonPropertyName("prices")]
            public Dictionary<int, decimal> Prices { get; set; }
            
            [JsonPropertyName("stock")]
            public Dictionary<string, int> Stock { get; set; }
            
            [JsonPropertyName("locations")]
            public Dictionary<string, int> Locations { get; set; }
            
            [JsonPropertyName("text_fields")] 
            public Dictionary<string, object> TextFields { get; set; }

            [JsonPropertyName("images")]
            public List<string> Images { get; set; }

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
}