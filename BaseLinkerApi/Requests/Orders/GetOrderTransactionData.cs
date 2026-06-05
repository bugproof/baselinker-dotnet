using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to retrieve transaction details for a selected order.
/// </summary>
public class GetOrderTransactionData : IRequest<GetOrderTransactionData.Response>
{
    /// <summary>
    /// Order Identifier from BaseLinker order manager
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// (optional, false by default) Whether to include detailed tax breakdown with order_lines structure.
    /// </summary>
    [JsonPropertyName("include_complex_taxes")]
    public bool? IncludeComplexTaxes { get; set; }

    /// <summary>
    /// (optional, true by default) Whether to include legacy Amazon fulfillment data for backward compatibility.
    /// </summary>
    [JsonPropertyName("include_amazon_data")]
    public bool? IncludeAmazonData { get; set; }

    public class OrderItem
    {
        /// <summary>
        /// Product SKU or identifier
        /// </summary>
        [JsonPropertyName("itemId")]
        public string ItemId { get; set; }

        /// <summary>
        /// Additional identifier ("p" + sku)
        /// </summary>
        [JsonPropertyName("outerItemId")]
        public string OuterItemId { get; set; }

        /// <summary>
        /// Shipping costs and taxes for this specific product
        /// </summary>
        [JsonPropertyName("shipping")]
        public object Shipping { get; set; }

        /// <summary>
        /// Array of tax objects applied to the product
        /// </summary>
        [JsonPropertyName("taxes")]
        public List<object> Taxes { get; set; }

        /// <summary>
        /// Additional not parsed data
        /// </summary>
        [JsonExtensionData] public Dictionary<string, JsonElement>? ExtensionsData { get; set; }
    }

    public class Response : ResponseBase
    {
        /// <summary>
        /// Order currency code
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// [Only for Amazon] An array of information about the Amazon fulfillment shipments found.
        /// </summary>
        [JsonPropertyName("fulfillment_shipments")]
        public List<AmazonFulfillmentShipment> FulfillmentShipments { get; set; }

        /// <summary>
        /// [Only for Amazon Vendor] Amazon fulfillment center identifier. (Requires providing "include_amazon_data" parameter)
        /// </summary>
        [JsonPropertyName("fulfillment_center_id")]
        public string FulfillmentCenterId { get; set; }

        /// <summary>
        /// Ship date from (unix time format)
        /// </summary>
        [JsonPropertyName("ship_date_from")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset ShipDateFrom { get; set; }

        /// <summary>
        /// Ship date to (unix time format)
        /// </summary>
        [JsonPropertyName("ship_date_to")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset ShipDateTo { get; set; }

        /// <summary>
        /// Delivery date from (unix time format)
        /// </summary>
        [JsonPropertyName("delivery_date_from")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DeliveryDateFrom { get; set; }

        /// <summary>
        /// Delivery date to (unix time format)
        /// </summary>
        [JsonPropertyName("delivery_date_to")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DeliveryDateTo { get; set; }

        /// <summary>
        /// Transaction identifier from marketplace
        /// </summary>
        [JsonPropertyName("marketplace_transaction_id")]
        public string MarketplaceTransactionId { get; set; }

        /// <summary>
        /// Marketplace account identifier
        /// </summary>
        [JsonPropertyName("account_id")]
        public int AccountId { get; set; }

        /// <summary>
        /// Transaction date (unix timestamp)
        /// </summary>
        [JsonPropertyName("transaction_date")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset TransactionDate { get; set; }

        /// <summary>
        /// (only when include_complex_taxes=true) Detailed tax breakdown per product.
        /// </summary>
        [JsonPropertyName("order_items")]
        public List<OrderItem> OrderItems { get; set; }
    }
}
