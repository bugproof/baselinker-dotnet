using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to get the invoice file from BaseLinker.
/// </summary>
public class GetInvoiceFile : IRequest<GetInvoiceFile.Response>
{
    /// <summary>
    /// BaseLinker invoice identifier
    /// </summary>
    [JsonPropertyName("invoice_id")]
    public int InvoiceId { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// Invoice file in binary format
        /// </summary>
        [JsonPropertyName("invoice")]
        [JsonConverter(typeof(ByteArrayToBase64WithPrefixConverter))]
        public byte[] Invoice { get; set; }

        /// <summary>
        /// BaseLinker invoice number
        /// </summary>
        [JsonPropertyName("invoice_number")]
        public string InvoiceNumber { get; set; }
    }
}