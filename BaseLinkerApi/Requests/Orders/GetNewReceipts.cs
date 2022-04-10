using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// <para>The method allows you to retrieve receipts waiting to be issued.</para>
/// <para>This method should be used in creating integration with a fiscal printer.</para>
/// <para>The method can be requested for new receipts every e.g. 10 seconds.</para>
/// <para>If any receipts appear in response, they should be confirmed by the setOrderReceipt method after printing to disappear from the waiting list.</para>
/// </summary>
public class GetNewReceipts : IRequest<GetNewReceipts.Response>
{
    /// <summary>
    /// (optional) The numbering series ID allows filtering by the receipt numbering series.
    /// Using multiple series numbering for receipts is recommended when the user has multiple fiscal printers. Each fiscal printer should have a separate series.
    /// </summary>
    [JsonPropertyName("series_id")]
    public int? SeriesId { get; set; }
        
    public class Order
    {
        [JsonPropertyName("receipt_id")]
        public int ReceiptId { get; set; }

        [JsonPropertyName("receipt_full_nr")]
        public string ReceiptFullNr { get; set; }

        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        [JsonPropertyName("date_add")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateAdd { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("ean")]
        public string Ean { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("orders")]
        public List<Order> Orders { get; set; }
    }
}