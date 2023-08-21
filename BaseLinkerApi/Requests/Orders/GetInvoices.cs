using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to download invoices issued from the BaseLinker order manager. The list of invoices can be limited using filters described in the method parameters. Maximum 100 invoices are returned at a time.
/// </summary>
public class GetInvoices : IRequest<GetInvoices.Response>
{
    /// <summary>
    /// (optional) Invoice identifier. Completing this field will result in downloading information about only one specific invoice.
    /// </summary>
    [JsonPropertyName("invoice_id")]
    public int? InvoiceId { get; set; }
        
    /// <summary>
    /// (optional) Order identifier. Completing this field will result in downloading information only about the invoice associated with this order (if the order has an invoice created).
    /// </summary>
    [JsonPropertyName("order_id")]
    public int? OrderId { get; set; }
        
    /// <summary>
    /// (optional) Date from which invoices are to be collected. Unix time stamp format.
    /// </summary>
    [JsonPropertyName("date_from")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? DateFrom { get; set; }
        
    /// <summary>
    /// (optional) The invoice ID number from which subsequent invoices are to be retrieved.
    /// </summary>
    [JsonPropertyName("id_from")]
    public int? IdFrom { get; set; }
        
    /// <summary>
    /// (optional) numbering series ID that allows filtering after the invoice numbering series.
    /// </summary>
    [JsonPropertyName("series_id")]
    public int? SeriesId { get; set; }
        
    /// <summary>
    /// (optional, true by default) Download external invoices as well.
    /// </summary>
    [JsonPropertyName("get_external_invoices")]
    public bool? GetExternalInvoices { get; set; }
        
    public class Response : ResponseBase
    {
        public class Item
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("price_brutto")]
            public decimal PriceBrutto { get; set; }

            [JsonPropertyName("price_netto")]
            public decimal PriceNetto { get; set; }

            [JsonPropertyName("tax_rate")]
            public double TaxRate { get; set; }

            [JsonPropertyName("quantity")]
            public int Quantity { get; set; }
            
            /// <summary>
            /// Additional not parsed data
            /// </summary>
            [JsonExtensionData] public Dictionary<string, JsonElement>? ExtensionsData { get; set; }
        }

        public class Invoice
        {
            [JsonPropertyName("invoice_id")]
            public int InvoiceId { get; set; }

            [JsonPropertyName("order_id")]
            public int OrderId { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("number")]
            public string Number { get; set; }

            [JsonPropertyName("year")]
            public int Year { get; set; }

            [JsonPropertyName("month")]
            public int Month { get; set; }

            [JsonPropertyName("sub_id")]
            public int SubId { get; set; }

            [JsonPropertyName("postfix")]
            public string Postfix { get; set; }

            [JsonPropertyName("date_add")]
            [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
            public DateTimeOffset DateAdd { get; set; }

            [JsonPropertyName("date_sell")]
            [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
            public DateTimeOffset DateSell { get; set; }

            [JsonPropertyName("date_pay_to")]
            [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
            public DateTimeOffset DatePayTo { get; set; }

            [JsonPropertyName("currency")]
            public string Currency { get; set; }

            [JsonPropertyName("total_price_brutto")]
            public decimal TotalPriceBrutto { get; set; }

            [JsonPropertyName("total_price_netto")]
            public decimal TotalPriceNetto { get; set; }

            [JsonPropertyName("invoice_fullname")]
            public string InvoiceFullname { get; set; }

            [JsonPropertyName("invoice_company")]
            public string InvoiceCompany { get; set; }

            [JsonPropertyName("invoice_nip")]
            public string InvoiceNip { get; set; }

            [JsonPropertyName("invoice_address")]
            public string InvoiceAddress { get; set; }

            [JsonPropertyName("invoice_city")]
            public string InvoiceCity { get; set; }

            [JsonPropertyName("invoice_postcode")]
            public string InvoicePostcode { get; set; }

            [JsonPropertyName("invoice_country")]
            public string InvoiceCountry { get; set; }

            [JsonPropertyName("invoice_country_code")]
            public string InvoiceCountryCode { get; set; }

            [JsonPropertyName("seller")]
            public string Seller { get; set; }
            
            [JsonPropertyName("issuer")]
            public string Issuer { get; set; }

            [JsonPropertyName("payment")]
            public string Payment { get; set; }

            [JsonPropertyName("correcting_to_invoice_id")]
            public int CorrectingToInvoiceId { get; set; }

            [JsonPropertyName("correcting_reason")]
            public string CorrectingReason { get; set; }

            [JsonPropertyName("correcting_items")]
            public bool CorrectingItems { get; set; }

            [JsonPropertyName("correcting_data")]
            public bool CorrectingData { get; set; }

            [JsonPropertyName("external_invoice_number")]
            public string ExternalInvoiceNumber { get; set; }

            [JsonPropertyName("exchange_currency")]
            public string ExchangeCurrency { get; set; }

            [JsonPropertyName("exchange_rate")]
            public decimal? ExchangeRate { get; set; }

            [JsonPropertyName("exchange_date")]
            // TODO: DateTime? converter "YYYY-MM-dd" or "" (empty string) to null
            public string ExchangeDate { get; set; }

            [JsonPropertyName("exchange_info")]
            public string ExchangeInfo { get; set; }

            [JsonPropertyName("external_id")]
            public string ExternalId { get; set; }

            [JsonPropertyName("items")]
            public List<Item> Items { get; set; }
            
            /// <summary>
            /// Additional not parsed data
            /// </summary>
            [JsonExtensionData] public Dictionary<string, JsonElement>? ExtensionsData { get; set; }
        }
            
        [JsonPropertyName("invoices")]
        public List<Invoice> Invoices { get; set; }
    }
}