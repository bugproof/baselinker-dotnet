using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve a list of tags for a BaseLinker catalog.
/// </summary>
public class GetInventoryTags : IRequest<GetInventoryTags.Response>
{
    public class Response : ResponseBase
    {
        /// <summary>
        /// A list containing available tags.
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
