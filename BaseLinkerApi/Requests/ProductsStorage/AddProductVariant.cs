using System;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductsStorage;

/// <summary>
/// The method allows to add a new variant to the product in BaseLinker storage. Providing the variant together with the ID, causes an update of the previously saved variant.
/// </summary>
[Obsolete]
public class AddProductVariant : IRequest<AddProductVariant.Response>
{
    [JsonPropertyName("storage_id")]
    public string StorageId { get; set; }

    [JsonPropertyName("product_id")]
    public string ProductId { get; set; }

    /// <summary>
    /// Product variant ID. Given only for updates. Should be left blank when creating a new variant. The new variant identifier is returned as a response to this method.
    /// </summary>
    [JsonPropertyName("variant_id")]
    public int? VariantId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("price_brutto")]
    public decimal PriceBrutto { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// The identifier of the storage, where the product was added or changed in format "[type:bl|shop|warehouse]_[id:int]" (e.g. "shop_2445").
        /// </summary>
        [JsonPropertyName("storage_id")]
        public string StorageId { get; set; }

        /// <summary>
        /// The number of the product to which variant has been added/changed.
        /// </summary>
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// The number of an added or updated product variant in BaseLinker storage. In an external application you must create a link between the internal number and the number received here. It will later be used to update the added product variant. This number will also be given in the order items in the getOrders function.
        /// </summary>
        [JsonPropertyName("variant_id")]
        public string VariantId { get; set; }
    }
}