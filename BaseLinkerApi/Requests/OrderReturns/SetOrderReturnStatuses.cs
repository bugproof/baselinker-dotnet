using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows you to batch set order return statuses.
/// </summary>
public class SetOrderReturnStatuses : IRequest
{
    /// <summary>
    /// Array of Order return ID numbers
    /// </summary>
    [JsonPropertyName("return_ids")]
    public List<int> ReturnIds { get; set; }

    /// <summary>
    /// Order return status ID number. The status list can be retrieved using getOrderReturnStatusList.
    /// </summary>
    [JsonPropertyName("status_id")]
    public int StatusId { get; set; }
}
