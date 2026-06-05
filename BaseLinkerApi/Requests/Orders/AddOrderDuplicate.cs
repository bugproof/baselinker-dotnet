using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to add a new order to the BaseLinker order manager by duplicating an existing order.
/// The new order will have the same data as the original order, but with a different ID.
/// </summary>
public class AddOrderDuplicate : IRequest<AddOrderDuplicate.Response>
{
    /// <summary>
    /// ID of the order to duplicate
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// ID of added order.
        /// </summary>
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }
    }
}
