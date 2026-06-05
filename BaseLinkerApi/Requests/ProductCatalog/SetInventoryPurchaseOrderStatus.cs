using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to change the status of a purchase order.
/// </summary>
public class SetInventoryPurchaseOrderStatus : IRequest
{
    /// <summary>
    /// Purchase order identifier
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// New order status. Available values: 0 - draft, 1 - sent, 2 - received, 3 - completed, 4 - completed partially, 5 - canceled
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    public class CompletedItem
    {
        /// <summary>
        /// Item identifier
        /// </summary>
        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }

        /// <summary>
        /// Received quantity
        /// </summary>
        [JsonPropertyName("completed_quantity")]
        public int CompletedQuantity { get; set; }
    }

    /// <summary>
    /// (optional) List of items received.
    /// </summary>
    [JsonPropertyName("completed_items")]
    public List<CompletedItem> CompletedItems { get; set; }
}
