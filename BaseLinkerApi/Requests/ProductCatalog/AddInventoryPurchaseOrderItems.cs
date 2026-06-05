using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to add items to an existing purchase order. Entering the product with the ID and price updates
/// the previously saved position only if all other parameters match. If any parameter differs (e.g. location), a new item will be added.
/// </summary>
public class AddInventoryPurchaseOrderItems : IRequest<AddInventoryPurchaseOrderItems.Response>
{
    /// <summary>
    /// Purchase order identifier
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    public class Item
    {
        /// <summary>
        /// Product identifier
        /// </summary>
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// Item quantity
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Item unit cost
        /// </summary>
        [JsonPropertyName("item_cost")]
        public decimal ItemCost { get; set; }

        /// <summary>
        /// (optional) Product code from supplier
        /// </summary>
        [JsonPropertyName("supplier_code")]
        public string? SupplierCode { get; set; }

        /// <summary>
        /// (optional) Storage location
        /// </summary>
        [JsonPropertyName("location")]
        public string? Location { get; set; }

        /// <summary>
        /// (optional) Batch number
        /// </summary>
        [JsonPropertyName("batch")]
        public string? Batch { get; set; }

        /// <summary>
        /// (optional) Expiry date
        /// </summary>
        [JsonPropertyName("expiry_date")]
        public string? ExpiryDate { get; set; }

        /// <summary>
        /// (optional) Serial number
        /// </summary>
        [JsonPropertyName("serial_no")]
        public string? SerialNo { get; set; }

        /// <summary>
        /// (optional) Item comments or notes
        /// </summary>
        [JsonPropertyName("comments")]
        public string? Comments { get; set; }
    }

    /// <summary>
    /// List of items to add.
    /// </summary>
    [JsonPropertyName("items")]
    public List<Item> Items { get; set; }

    public class Response : ResponseBase
    {
        public class CreatedItem
        {
            /// <summary>
            /// Item identifier
            /// </summary>
            [JsonPropertyName("item_id")]
            public int ItemId { get; set; }

            /// <summary>
            /// Item position in order
            /// </summary>
            [JsonPropertyName("position")]
            public int Position { get; set; }
        }

        [JsonPropertyName("items")]
        public List<CreatedItem> Items { get; set; }
    }
}
