using System;
using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.ProductsStorage
{
    /// <summary>
    /// The method allows you to remove categories from BaseLinker storage. Along with the category, the products contained therein are removed (however, this does not apply to products in subcategories). The subcategories will be changed to the highest level categories.
    /// </summary>
    [Obsolete]
    public class DeleteCategory : IRequest
    {
        [JsonPropertyName("storage_id")]
        public string StorageId { get; set; }

        [JsonPropertyName("category_id")]
        public string CategoryId { get; set; }
    }
}