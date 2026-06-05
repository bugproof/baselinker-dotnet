using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// This method allows you to retrieve a list of inventory documents from BaseLinker.
/// It supports pagination and optional filtering by document type, date range, etc.
/// </summary>
public class GetInventoryDocuments : IRequest<GetInventoryDocuments.Response>
{
    /// <summary>
    /// (optional) A specific inventory document ID
    /// </summary>
    [JsonPropertyName("filter_document_id")]
    public int? FilterDocumentId { get; set; }

    /// <summary>
    /// (optional) The document type: 0 - GR (Goods Received), 1 - IGR (Internal Goods Received), 2 - GI (Goods Issue),
    /// 3 - IGI (Internal Goods Issue), 4 - IT (Internal Transfer), 5 - OB (Opening Balance)
    /// </summary>
    [JsonPropertyName("filter_document_type")]
    public int? FilterDocumentType { get; set; }

    /// <summary>
    /// (optional) The document status: 0 - Draft, 1 - Confirmed
    /// </summary>
    [JsonPropertyName("filter_document_status")]
    public int? FilterDocumentStatus { get; set; }

    /// <summary>
    /// (optional) The minimum creation date (unix timestamp) to filter by
    /// </summary>
    [JsonPropertyName("filter_date_from")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? FilterDateFrom { get; set; }

    /// <summary>
    /// (optional) The maximum creation date (unix timestamp) to filter by
    /// </summary>
    [JsonPropertyName("filter_date_to")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? FilterDateTo { get; set; }

    /// <summary>
    /// (optional) The warehouse ID
    /// </summary>
    [JsonPropertyName("filter_warehouse_id")]
    public int? FilterWarehouseId { get; set; }

    /// <summary>
    /// (optional) Results page number (100 documents per page, numbered from 1)
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    public class Document
    {
        /// <summary>
        /// The unique identifier of the inventory document
        /// </summary>
        [JsonPropertyName("document_id")]
        public int DocumentId { get; set; }

        /// <summary>
        /// The document type: 0-GR, 1-IGR, 2-GI, 3-IGI, 4-IT, 5-OB
        /// </summary>
        [JsonPropertyName("document_type")]
        public int DocumentType { get; set; }

        /// <summary>
        /// The document status: 0 - Draft, 1 - Confirmed
        /// </summary>
        [JsonPropertyName("document_status")]
        public int DocumentStatus { get; set; }

        /// <summary>
        /// The document direction (0 = incoming, 1 = outgoing)
        /// </summary>
        [JsonPropertyName("direction")]
        public int Direction { get; set; }

        /// <summary>
        /// The ID of the document series
        /// </summary>
        [JsonPropertyName("document_series_id")]
        public int DocumentSeriesId { get; set; }

        /// <summary>
        /// The full document number
        /// </summary>
        [JsonPropertyName("full_number")]
        public string FullNumber { get; set; }

        /// <summary>
        /// The creation date of the document in unix time
        /// </summary>
        [JsonPropertyName("date_created")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The confirmation date in unix time. 0 if not confirmed
        /// </summary>
        [JsonPropertyName("date_confirmed")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateConfirmed { get; set; }

        /// <summary>
        /// The main warehouse ID used for this document
        /// </summary>
        [JsonPropertyName("warehouse_id")]
        public int WarehouseId { get; set; }

        /// <summary>
        /// The second (destination) warehouse ID for transfers
        /// </summary>
        [JsonPropertyName("warehouse_id2")]
        public int WarehouseId2 { get; set; }

        /// <summary>
        /// Number of items in the document
        /// </summary>
        [JsonPropertyName("items_count")]
        public int ItemsCount { get; set; }

        /// <summary>
        /// Total quantity of products in the document
        /// </summary>
        [JsonPropertyName("total_quantity")]
        public int TotalQuantity { get; set; }

        /// <summary>
        /// Total value (price) for the entire document
        /// </summary>
        [JsonPropertyName("total_price")]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Source object type: 1-order, 2-purchase order, 3-stock take, 4-order return, 7-fulfillment delivery, 8-transfer
        /// </summary>
        [JsonPropertyName("connection_type")]
        public int ConnectionType { get; set; }

        /// <summary>
        /// Source object ID
        /// </summary>
        [JsonPropertyName("connection_id")]
        public int ConnectionId { get; set; }

        /// <summary>
        /// Additional not parsed data
        /// </summary>
        [JsonExtensionData] public Dictionary<string, JsonElement>? ExtensionsData { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("documents")]
        public List<Document> Documents { get; set; }
    }
}
