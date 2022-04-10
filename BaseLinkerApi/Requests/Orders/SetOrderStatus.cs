using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.Orders;

public class SetOrderStatus : IRequest
{
    /// <summary>
    /// Order ID number
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// Status ID number. The status list can be retrieved using getOrderStatusList.
    /// </summary>
    [JsonPropertyName("status_id")]
    public int StatusId { get; set; }
}