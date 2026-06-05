using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows you to change order return status.
/// </summary>
public class SetOrderReturnStatus : IRequest
{
    /// <summary>
    /// Order return ID number.
    /// </summary>
    [JsonPropertyName("return_id")]
    public int ReturnId { get; set; }

    /// <summary>
    /// Status ID number. The status list can be retrieved using getOrderReturnStatusList.
    /// </summary>
    [JsonPropertyName("status_id")]
    public int StatusId { get; set; }
}
