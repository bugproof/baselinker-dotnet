using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows to retrieve price groups existing in BaseLinker storage
/// </summary>
public class GetInventoryPriceGroups : IRequest<GetInventoryPriceGroups.Response>
{
    public class PriceGroup
    {
        /// <summary>
        /// Price group identifier
        /// </summary>
        [JsonPropertyName("price_group_id")]
        public int PriceGroupId { get; set; }

        /// <summary>
        /// Name of the price group
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Price group description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 3-letter currency symbol e.g. PLN, EUR
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Flag indicating whether the price group is default
        /// </summary>
        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("price_groups")]
        public List<PriceGroup> PriceGroups { get; set; }
    }
}