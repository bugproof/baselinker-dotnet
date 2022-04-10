using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to retrieve a single receipt from the BaseLinker order manager. To retrieve a list of new receipts (when integrating a fiscal printer), use the getNewReceipts method.
/// </summary>
public class GetReceipt : IRequest<GetReceipt.Response>
{
    /// <summary>
    /// Receipt ID. Not required if order_id is provided.
    /// </summary>
    [JsonPropertyName("receipt_id")] 
    public int? ReceiptId { get; set; }
        
    /// <summary>
    /// Order ID. Not required if receipt_id is provided.
    /// </summary>
    [JsonPropertyName("order_id")]
    public int? OrderId { get; set; }
        
    public class Item
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("ean")]
        public string Ean { get; set; }

        [JsonPropertyName("price_brutto")]
        public decimal PriceBrutto { get; set; }

        [JsonPropertyName("tax_rate")]
        public double TaxRate { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("receipt_id")]
        public int ReceiptId { get; set; }

        [JsonPropertyName("series_id")]
        public int SeriesId { get; set; }

        [JsonPropertyName("receipt_full_nr")]
        public string ReceiptFullNr { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("month")]
        public int Month { get; set; }

        [JsonPropertyName("sub_id")]
        public int SubId { get; set; }

        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        [JsonPropertyName("date_add")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateAdd { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("nip")]
        public string Nip { get; set; }

        [JsonPropertyName("total_price_brutto")]
        public int TotalPriceBrutto { get; set; }

        [JsonPropertyName("external_receipt_number")]
        public string ExternalReceiptNumber { get; set; }

        [JsonPropertyName("exchange_currency")]
        public string ExchangeCurrency { get; set; }

        [JsonPropertyName("exchange_rate")]
        public string ExchangeRate { get; set; }

        [JsonPropertyName("exchange_date")]
        public string ExchangeDate { get; set; }

        [JsonPropertyName("exchange_info")]
        public string ExchangeInfo { get; set; }

        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }
}