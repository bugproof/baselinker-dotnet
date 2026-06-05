using System;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to create a new inventory document in BaseLinker storage.
/// Documents are created as draft and need to be confirmed by the user or setInventoryDocumentStatusConfirmed API method.
/// </summary>
public class AddInventoryDocument : IRequest<AddInventoryDocument.Response>
{
    /// <summary>
    /// Source warehouse identifier
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public int WarehouseId { get; set; }

    /// <summary>
    /// Document type: 0 - GR (Goods Received), 1 - IGR (Internal Goods Received), 2 - GI (Goods Issue),
    /// 3 - IGI (Internal Goods Issue), 4 - IT (Internal Transfer), 5 - OB (Opening Balance)
    /// </summary>
    [JsonPropertyName("document_type")]
    public int DocumentType { get; set; }

    /// <summary>
    /// (optional) Target warehouse identifier - required only for transfer documents (type 4)
    /// </summary>
    [JsonPropertyName("target_warehouse_id")]
    public int? TargetWarehouseId { get; set; }

    /// <summary>
    /// (optional) Date of document creation (unix timestamp). If not specified, the current date will be used.
    /// </summary>
    [JsonPropertyName("date_add")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? DateAdd { get; set; }

    /// <summary>
    /// (optional) Date of document execution (unix timestamp). If not specified, the current date will be used.
    /// </summary>
    [JsonPropertyName("date_execute")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? DateExecute { get; set; }

    /// <summary>
    /// (optional) Contractor description/notes
    /// </summary>
    [JsonPropertyName("contractor")]
    public string? Contractor { get; set; }

    /// <summary>
    /// (optional) Related invoice number
    /// </summary>
    [JsonPropertyName("invoice_no")]
    public string? InvoiceNo { get; set; }

    /// <summary>
    /// (optional) Document notes/description
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// Created document identifier
        /// </summary>
        [JsonPropertyName("document_id")]
        public int DocumentId { get; set; }

        /// <summary>
        /// Generated document number
        /// </summary>
        [JsonPropertyName("document_number")]
        public string DocumentNumber { get; set; }
    }
}
