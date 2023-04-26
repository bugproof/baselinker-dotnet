using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method returns types of order sources along with their IDs.
/// Order sources are grouped by their type that corresponds to a field order_source from the getOrders method.
/// Available source types are "personal", "shop" or "marketplace_code" e.g. "ebay", "amazon", "ceneo", "emag", "allegro", etc.
/// </summary>
public class GetOrderSources : IRequest<GetOrderSources.Response>
{
    public class Response : ResponseBase
    {
        [JsonPropertyName("sources")]
        public Dictionary<string, Dictionary<int, string>> Sources { get; set; }
    }
}