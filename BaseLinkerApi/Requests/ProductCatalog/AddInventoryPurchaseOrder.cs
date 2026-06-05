using System;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to create a new purchase order in BaseLinker storage. Orders are created as drafts by default.
/// </summary>
public class AddInventoryPurchaseOrder : IRequest<AddInventoryPurchaseOrder.Response>
{
    /// <summary>
    /// Warehouse identifier
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public int WarehouseId { get; set; }

    /// <summary>
    /// Supplier identifier
    /// </summary>
    [JsonPropertyName("supplier_id")]
    public int SupplierId { get; set; }

    /// <summary>
    /// Payer identifier
    /// </summary>
    [JsonPropertyName("payer_id")]
    public int PayerId { get; set; }

    /// <summary>
    /// Order currency (e.g. EUR, USD)
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// (optional) Order name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// (optional) Order description/notes
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// (optional) Related invoice number
    /// </summary>
    [JsonPropertyName("invoice_no")]
    public string? InvoiceNo { get; set; }

    /// <summary>
    /// (optional) Expected delivery date (unix timestamp) set when creating the purchase order.
    /// </summary>
    [JsonPropertyName("date_delivery_expected")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? DateDeliveryExpected { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// Created purchase order identifier
        /// </summary>
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        /// <summary>
        /// Generated document number
        /// </summary>
        [JsonPropertyName("document_number")]
        public string DocumentNumber { get; set; }
    }
}
