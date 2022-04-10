using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to add an external PDF file to an invoice previously issued from BaseLinker. It enables replacing a standard invoice from BaseLinker with an invoice issued e.g. in an ERP program.
/// </summary>
public class AddOrderInvoiceFile : IRequest<ResponseBase>
{
    /// <summary>
    /// BaseLinker invoice identifier
    /// </summary>
    [JsonPropertyName("invoice_id")]
    public int InvoiceId { get; set; }

    /// <summary>
    /// Invoice PDF file in binary format encoded in base64, at the very beginning of the invoice string provide a prefix "data:" e.g. "data:4AAQSkSzkJRgABA[...]"
    /// </summary>
    [JsonPropertyName("file")]
    [JsonConverter(typeof(ByteArrayToBase64WithPrefixConverter))]
    public byte[] File { get; set; }

    /// <summary>
    /// External system invoice number (overwrites BaseLinker invoice number)
    /// </summary>
    [JsonPropertyName("external_invoice_number")]
    public string ExternalInvoiceNumber { get; set; }
}