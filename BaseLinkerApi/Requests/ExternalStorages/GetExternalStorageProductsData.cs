using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ExternalStorages;

/// <summary>
/// The method allows to retrieve detailed data of selected products from an external storage (shop/wholesaler) connected to BaseLinker.
/// </summary>
public class GetExternalStorageProductsData : IRequest<GetExternalStorageProductsData.Response>
{
    /// <summary>
    /// Storage ID in format "[type:shop|warehouse]_[id:int]" (e.g. "shop_2445").
    /// </summary>
    [JsonPropertyName("storage_id")]
    public string StorageId { get; set; }

    [JsonPropertyName("products")]
    public List<int> Products { get; set; }

    public class Variant
    {
        [JsonPropertyName("variant_id")]
        public int VariantId { get; set; }
            
        [JsonPropertyName("name")]
        public string Name { get; set; }
            
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
            
        [JsonPropertyName("quantity")] 
        public int Quantity { get; set; }
            
        [JsonPropertyName("ean")]
        public string Ean { get; set; }
    }
        
    public class Product
    {
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }
            
        [JsonPropertyName("ean")]
        public string Ean { get; set; }
            
        [JsonPropertyName("sku")]
        public string Sku { get; set; }
            
        [JsonPropertyName("name")]
        public string Name { get; set; }
            
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
            
        [JsonPropertyName("price_netto")]
        public decimal PriceNetto { get; set; }
            
        [JsonPropertyName("price_brutto")]
        public decimal PriceBrutto { get; set; }
            
        [JsonPropertyName("price_wholesale_netto")]
        public decimal PriceWholesaleNetto { get; set; }

        [JsonPropertyName("tax_rate")]
        public double TaxRate { get; set; }
            
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
            
        [JsonPropertyName("description")]
        public string Description { get; set; }
            
        [JsonPropertyName("description_extra1")]
        public string DescriptionExtra1 { get; set; }
            
        [JsonPropertyName("description_extra2")]
        public string DescriptionExtra2 { get; set; }
            
        [JsonPropertyName("man_name")]
        public string ManufacturerName { get; set; }
            
        [JsonPropertyName("man_image")]
        public string ManufacturerLogoImage { get; set; }

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
            
        [JsonPropertyName("images")]
        public List<string> Images { get; set; }

        [JsonPropertyName("features")]
        public Dictionary<string, string> Features { get; set; }
            
        [JsonPropertyName("variants")] 
        public List<Variant> Variants { get; set; }
            
        [JsonExtensionData] 
        public Dictionary<string, object> AdditionalData { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("storage_id")]
        public string StorageId { get; set; }
            
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}