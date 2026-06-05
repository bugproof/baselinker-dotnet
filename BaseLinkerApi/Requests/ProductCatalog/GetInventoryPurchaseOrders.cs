using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve a list of purchase orders from BaseLinker storage.
/// </summary>
public class GetInventoryPurchaseOrders : IRequest<GetInventoryPurchaseOrders.Response>
{
    /// <summary>
    /// (optional) Warehouse ID. The list of identifiers can be retrieved using the method getInventoryWarehouses.
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public int? WarehouseId { get; set; }

    /// <summary>
    /// (optional) Limiting results to a specific supplier ID
    /// </summary>
    [JsonPropertyName("supplier_id")]
    public int? SupplierId { get; set; }

    /// <summary>
    /// (optional) Limiting results to a specific document series ID
    /// </summary>
    [JsonPropertyName("series_id")]
    public int? SeriesId { get; set; }

    /// <summary>
    /// (optional) Date from which documents should be retrieved (Unix timestamp)
    /// </summary>
    [JsonPropertyName("date_from")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? DateFrom { get; set; }

    /// <summary>
    /// (optional) Date up to which documents should be retrieved (Unix timestamp)
    /// </summary>
    [JsonPropertyName("date_to")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? DateTo { get; set; }

    /// <summary>
    /// (optional) Filtering by document number (full or partial match)
    /// </summary>
    [JsonPropertyName("filter_document_number")]
    public string? FilterDocumentNumber { get; set; }

    /// <summary>
    /// (optional) Results paging (100 documents per page)
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    public class PurchaseOrder
    {
        /// <summary>
        /// Purchase order identifier
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Purchase order name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Purchase order series identifier
        /// </summary>
        [JsonPropertyName("series_id")]
        public int SeriesId { get; set; }

        /// <summary>
        /// Full document number
        /// </summary>
        [JsonPropertyName("document_number")]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Purchase order creation date (Unix timestamp)
        /// </summary>
        [JsonPropertyName("date_created")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// Purchase order sent date (Unix timestamp)
        /// </summary>
        [JsonPropertyName("date_sent")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateSent { get; set; }

        /// <summary>
        /// (optional) Purchase order received date (Unix timestamp)
        /// </summary>
        [JsonPropertyName("date_received")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset? DateReceived { get; set; }

        /// <summary>
        /// (optional) Purchase order completed date (Unix timestamp)
        /// </summary>
        [JsonPropertyName("date_completed")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset? DateCompleted { get; set; }

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
        /// (optional) Payer identifier
        /// </summary>
        [JsonPropertyName("payer_id")]
        public int? PayerId { get; set; }

        /// <summary>
        /// Purchase order currency (e.g. EUR, USD)
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Total quantity of items
        /// </summary>
        [JsonPropertyName("total_quantity")]
        public int TotalQuantity { get; set; }

        /// <summary>
        /// Total quantity of received items
        /// </summary>
        [JsonPropertyName("completed_total_quantity")]
        public int CompletedTotalQuantity { get; set; }

        /// <summary>
        /// Total order cost
        /// </summary>
        [JsonPropertyName("total_cost")]
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Total cost of received items
        /// </summary>
        [JsonPropertyName("completed_total_cost")]
        public decimal CompletedTotalCost { get; set; }

        /// <summary>
        /// Number of unique items in purchase order
        /// </summary>
        [JsonPropertyName("items_count")]
        public int ItemsCount { get; set; }

        /// <summary>
        /// Number of unique items received
        /// </summary>
        [JsonPropertyName("completed_items_count")]
        public int CompletedItemsCount { get; set; }

        /// <summary>
        /// (optional) Related invoice number
        /// </summary>
        [JsonPropertyName("cost_invoice_no")]
        public string CostInvoiceNo { get; set; }

        /// <summary>
        /// (optional) Purchase order notes/description
        /// </summary>
        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Order status. 0 - draft, 1 - sent, 2 - received, 3 - completed, 4 - completed partially, 5 - canceled
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// Additional not parsed data
        /// </summary>
        [JsonExtensionData] public Dictionary<string, JsonElement>? ExtensionsData { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("purchase_orders")]
        public List<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
