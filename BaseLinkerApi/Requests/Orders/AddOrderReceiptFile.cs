using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to add an external PDF file to a receipt previously issued from BaseLinker.
/// It enables replacing a standard receipt from BaseLinker with a receipt issued e.g. in an ERP program.
/// </summary>
public class AddOrderReceiptFile : IRequest<ResponseBase>
{
    /// <summary>
    /// BaseLinker receipt identifier
    /// </summary>
    [JsonPropertyName("receipt_id")]
    public int ReceiptId { get; set; }
    
    /// <summary>
    /// Receipt PDF file
    /// </summary>
    [JsonPropertyName("file")]
    [JsonConverter(typeof(ByteArrayToBase64WithPrefixConverter))]
    public byte[] File { get; set; }
    
    /// <summary>
    /// External system receipt number (overwrites BaseLinker receipt number)
    /// </summary>
    [JsonPropertyName("external_receipt_number")]
    public string ExternalReceiptNumber { get; set; }
}