using System;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to mark orders with a receipt already issued.
/// </summary>
public class SetOrderReceipt : IRequest
{
    /// <summary>
    /// Receipt_id number received in the getNewReceipts method
    /// </summary>
    [JsonPropertyName("receipt_id")]
    public int ReceiptId { get; set; }
        
    /// <summary>
    /// The number of the issued receipt (may be blank if the printer does not return the number)
    /// </summary>
    [JsonPropertyName("receipt_nr")]
    public string? ReceiptNr { get; set; }

    /// <summary>
    /// Receipt printing date (unixtime format)
    /// </summary>
    [JsonPropertyName("date")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset Date { get; set; }
        
    /// <summary>
    /// Flag indicating whether an error occurred during receipt printing (false by default)
    /// </summary>
    [JsonPropertyName("printer_error")] 
    public bool? PrinterError { get; set; }
    
    /// <summary>
    /// (optional) Printer name
    /// </summary>
    [JsonPropertyName("printer_name")] 
    public string? PrinterName { get; set; }
}