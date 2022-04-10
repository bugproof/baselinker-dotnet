using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ExternalStorages;

/// <summary>
/// The method allows you to retrieve a category list from an external storage (shop/wholesale) connected to BaseLinker.
/// </summary>
public class GetExternalStorageCategories : IRequest<GetExternalStorageCategories.Response>
{
    /// <summary>
    /// Storage ID in format "[type:shop|warehouse]_[id:int]" (e.g. "shop_2445").
    /// </summary>
    [JsonPropertyName("storage_id")]
    public string StorageId { get; set; }

    public class Category
    {
        /// <summary>
        /// Category ID.
        /// </summary>
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Parent category identifier.
        /// </summary>
        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }
    }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// Storage ID in format "[type:shop|warehouse]_[id:int]" (e.g. "shop_2445").
        /// </summary>
        [JsonPropertyName("storage_id")]
        public string StorageId { get; set; }

        [JsonPropertyName("categories")]
        public List<Category> Categories { get; set; }
    }
}