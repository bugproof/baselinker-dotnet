using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ExternalStorages;

/// <summary>
/// The method allows to bulk update the product stock (and/or variants) in an external storage (shop/wholesaler) connected to BaseLinker. Maximum 1000 products at a time.
/// </summary>
public class UpdateExternalStorageProductsQuantity : IRequest<UpdateExternalStorageProductsQuantity.Response>
{
    /// <summary>
    /// Storage ID in format "[type:shop|warehouse]_[id:int]" (e.g. "shop_2445").
    /// </summary>
    [JsonPropertyName("storage_id")]
    public string StorageId { get; set; }

    /// <summary>
    /// An array of products. Each product is a separate element of the array. The product consists of a 3 element array of components:<br/>
    /// 0 => product ID number (varchar)<br/>
    /// 1 => variant ID number (0 if the main product is changed, not the variant) (int)<br/>
    /// 2 => Stock quantity (int)
    /// </summary>
    [JsonPropertyName("products")]
    public List<List<int>> Products { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// Number of received items.
        /// </summary>
        [JsonPropertyName("counter")]
        public int Counter { get; set; }

        /// <summary>
        /// An array of warning notices for product updates. The key to each item is the identifier of the sent category, the value is an error message when adding. Only the keys containing errors are returned.
        /// </summary>
        [JsonPropertyName("warnings")]
        public Dictionary<string, string> Warnings { get; set; }
    }
}