using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to remove a specific product from the order.
/// </summary>
public class DeleteOrderProduct : IRequest
{
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    //TODO: int or string??!?!?!?!? doc is inconsistent 
    [JsonPropertyName("order_product_id")]
    public string OrderProductId { get; set; }
}