using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

public class AmazonFulfillmentShipment
{
    [JsonPropertyName("product_name")]
    public string ProductName { get; set; }

    [JsonPropertyName("product_sku")]
    public string ProductSku { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("fba")]
    public string Fba { get; set; }
}
    
/// <summary>
/// The method allows you to retrieve transaction details for a selected order (it now works only for orders from Amazon)
/// </summary>
public class GetOrderTransactionDetails : IRequest<GetOrderTransactionDetails.Response>
{
    /// <summary>
    /// Order Identifier from BaseLinker order manager
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("amazon_fulfillment_shipments")]
        public List<AmazonFulfillmentShipment> AmazonFulfillmentShipments { get; set; }
            
        [JsonPropertyName("amazon_ship_date_from")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset AmazonShipDateFrom { get; set; }

        [JsonPropertyName("amazon_ship_date_to")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset AmazonShipDateTo { get; set; }

        [JsonPropertyName("amazon_delivery_date_from")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset AmazonDeliveryDateFrom { get; set; }

        [JsonPropertyName("amazon_delivery_date_to")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset AmazonDeliveryDateTo { get; set; }
    }
}