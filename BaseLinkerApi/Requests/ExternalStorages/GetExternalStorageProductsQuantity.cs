using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ExternalStorages;

/// <summary>
/// The method allows to retrieve stock from an external storage (shop/wholesaler) connected to BaseLinker.
/// </summary>
public class GetExternalStorageProductsQuantity : IRequest<GetExternalStorageProductsQuantity.Response>
{
    /// <summary>
    /// Storage ID in format "[type:shop|warehouse]_[id:int]" (e.g. "shop_2445").
    /// </summary>
    [JsonPropertyName("storage_id")]
    public string StorageId { get; set; }

    /// <summary>
    /// (optional) Results paging
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }
        
    public class Variant
    {
        [JsonPropertyName("variant_id")]
        public string VariantId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("variants")]
        public List<Variant> Variants { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("storage_id")]
        public string StorageId { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}