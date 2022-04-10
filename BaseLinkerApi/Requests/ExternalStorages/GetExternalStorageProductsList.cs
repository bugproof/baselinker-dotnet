using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ExternalStorages;

/// <summary>
/// The method allows to retrieve detailed data of selected products from an external storage (shop/wholesaler) connected to BaseLinker.
/// </summary>
public class GetExternalStorageProductsList : IRequest<GetExternalStorageProductsList.Response>
{
    /// <summary>
    /// Storage ID in format "[type:shop|warehouse]_[id:int]" (e.g. "shop_2445").
    /// </summary>
    [JsonPropertyName("storage_id")]
    public string StorageId { get; set; } = null!;

    [JsonPropertyName("filter_category_id")]
    public string? FilterCategoryId { get; set; }
        
    [JsonPropertyName("filter_sort")]
    public string? FilterSort { get; set; }
        
    [JsonPropertyName("filter_id")]
    public string? FilterId { get; set; }
        
    [JsonPropertyName("filter_ean")]
    public string? FilterEan { get; set; }
        
    [JsonPropertyName("filter_sku")]
    public string? FilterSku { get; set; }
        
    [JsonPropertyName("filter_name")]
    public string? FilterName { get; set; }
        
    [JsonPropertyName("filter_price_from")]
    public decimal? FilterPriceFrom { get; set; }
        
    [JsonPropertyName("filter_price_to")]
    public decimal? FilterPriceTo { get; set; }
        
    [JsonPropertyName("filter_quantity_from")]
    public int? FilterQuantityFrom { get; set; }
        
    [JsonPropertyName("filter_quantity_to")]
    public int? FilterQuantityTo { get; set; }
        
    [JsonPropertyName("filter_available")]
    public int? FilterAvailable { get; set; }
        
    [JsonPropertyName("page")]
    public int? Page { get; set; }
        
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

        [JsonPropertyName("price_brutto")]
        public decimal PriceBrutto { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("storage_id")]
        public string StorageId { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}