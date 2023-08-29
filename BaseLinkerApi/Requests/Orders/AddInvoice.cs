using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows to issue an order invoice.
/// </summary>
public class AddInvoice : IRequest<AddInvoice.Response>
{
    /// <summary>
    /// Order Identifier from BaseLinker order manager
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// Series numbering identifier
    /// </summary>
    [JsonPropertyName("series_id")]
    public int SeriesId { get; set; }
    
    /// <summary>
    /// (optional) VAT rate (refer to the documentation for usage)
    /// </summary>
    [JsonPropertyName("vat_rate")] 
    public object? VatRate { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// ID of the added invoice.
        /// </summary>
        [JsonPropertyName("invoice_id")]
        public int InvoiceId { get; set; }
    }
}