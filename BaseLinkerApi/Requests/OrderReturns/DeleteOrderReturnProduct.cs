using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows you to remove a specific product from the return.
/// </summary>
public class DeleteOrderReturnProduct : IRequest
{
    /// <summary>
    /// Order return ID.
    /// </summary>
    [JsonPropertyName("return_id")]
    public int ReturnId { get; set; }

    /// <summary>
    /// Order return item ID.
    /// </summary>
    [JsonPropertyName("order_return_product_id")]
    public int OrderReturnProductId { get; set; }
}
