using System;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductsStorage
{
    /// <summary>
    /// The method allows adding a category to the BaseLinker storage. Adding a category with the same ID again, updates the previously saved category.
    /// </summary>
    [Obsolete]
    public class AddCategory : IRequest<AddCategory.Response>
    {
        [JsonPropertyName("storage_id")]
        public string StorageId { get; set; }
        
        /// <summary>
        /// The category identifier to be provided for updates. Should be left blank when creating a new category.
        /// </summary>
        [JsonPropertyName("category_id")]
        public int? CategoryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }
        
        public class Response : ResponseBase
        {
            /// <summary>
            /// The identifier of the storage where the category has been added or modified in format "[type:bl|shop|warehouse]_[id:int]" (e.g. "shop_2445").
            /// </summary>
            [JsonPropertyName("storage_id")]
            public string StorageId { get; set; }

            /// <summary>
            /// Number of a category added or updated in BaseLinker storage. In an external application you should create a link between the internal number and the number received here. It will later be used to update the added category. This number is also used in addProducts and deleteCategory methods.
            /// </summary>
            [JsonPropertyName("category_id")]
            public int CategoryId { get; set; }
        }
    }
}