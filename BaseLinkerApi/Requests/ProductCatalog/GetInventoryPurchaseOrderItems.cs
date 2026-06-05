using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve items from a specific purchase order.
/// </summary>
public class GetInventoryPurchaseOrderItems : IRequest<GetInventoryPurchaseOrderItems.Response>
{
    /// <summary>
    /// Purchase order identifier
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// (optional) Page number of the results if there are many items in a purchase order (100 items per page).
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    public class Item
    {
        /// <summary>
        /// Item identifier
        /// </summary>
        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }

        /// <summary>
        /// Product identifier
        /// </summary>
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// The line item number within the purchase order
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; set; }

        /// <summary>
        /// Product name on document
        /// </summary>
        [JsonPropertyName("product_name")]
        public string ProductName { get; set; }

        /// <summary>
        /// Product SKU
        /// </summary>
        [JsonPropertyName("product_sku")]
        public string ProductSku { get; set; }

        /// <summary>
        /// Product EAN
        /// </summary>
        [JsonPropertyName("product_ean")]
        public string ProductEan { get; set; }

        /// <summary>
        /// (optional) Product code from supplier
        /// </summary>
        [JsonPropertyName("supplier_code")]
        public string SupplierCode { get; set; }

        /// <summary>
        /// Ordered quantity
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Received quantity
        /// </summary>
        [JsonPropertyName("completed_quantity")]
        public int CompletedQuantity { get; set; }

        /// <summary>
        /// Item unit cost
        /// </summary>
        [JsonPropertyName("item_cost")]
        public decimal ItemCost { get; set; }

        /// <summary>
        /// (optional) Storage location
        /// </summary>
        [JsonPropertyName("location")]
        public string Location { get; set; }

        /// <summary>
        /// (optional) Expiry date
        /// </summary>
        [JsonPropertyName("expiry_date")]
        public string ExpiryDate { get; set; }

        /// <summary>
        /// (optional) Batch number
        /// </summary>
        [JsonPropertyName("batch")]
        public string Batch { get; set; }

        /// <summary>
        /// (optional) Serial number
        /// </summary>
        [JsonPropertyName("serial_no")]
        public string SerialNo { get; set; }

        /// <summary>
        /// (optional) Item comments or notes
        /// </summary>
        [JsonPropertyName("comments")]
        public string Comments { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }
}
