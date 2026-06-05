using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// Creates a new order by splitting selected products from an existing order.
/// The new order inherits all fields and information from the original one.
/// </summary>
public class AddOrderBySplit : IRequest<AddOrderBySplit.Response>
{
    /// <summary>
    /// ID of the order to split
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    public class ItemToSplit
    {
        /// <summary>
        /// ID of the product in the original order (from getOrders method)
        /// </summary>
        [JsonPropertyName("order_product_id")]
        public int OrderProductId { get; set; }

        /// <summary>
        /// Quantity to be moved (must be less than or equal to the original quantity)
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }

    /// <summary>
    /// A list of products to move to the new order.
    /// </summary>
    [JsonPropertyName("items_to_split")]
    public List<ItemToSplit> ItemsToSplit { get; set; }

    /// <summary>
    /// (optional) Delivery cost (net or gross, depending on order) to transfer to the new order.
    /// This amount will be deducted from the original order and assigned to the new one. Must not exceed the current delivery price.
    /// </summary>
    [JsonPropertyName("delivery_cost_to_split")]
    public double? DeliveryCostToSplit { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// ID of the newly created order
        /// </summary>
        [JsonPropertyName("new_order_id")]
        public int NewOrderId { get; set; }
    }
}
