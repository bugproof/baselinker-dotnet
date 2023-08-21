using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to batch set orders statuses
/// </summary>
public class SetOrderStatuses : IRequest<ResponseBase>
{
    /// <summary>
    /// Array of Order ID numbers
    /// </summary>
    [JsonPropertyName("order_ids")]
    public List<int> OrderIds { get; set; }
    
    [JsonPropertyName("status_id")] 
    public int StatusId { get; set; }
}