using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve a list of categories for a BaseLinker catalog.
/// </summary>
public class GetInventoryCategories : IRequest<GetInventoryCategories.Response>
{
    public class Category
    {
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("categories")]
        public List<Category> Categories { get; set; }
    }
}