using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows to search for orders related to the given e-mail address. This function is designed to be used in plugins for mail clients (Thunderbird, Outlook, etc.).
/// </summary>
public class GetOrdersByEmail : IRequest<GetOrdersByEmail.Response>
{
    /// <summary>
    /// The e-mail address we search for in orders.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }
        
    public class Order
    {
        /// <summary>
        /// Order Identifier from BaseLinker order manager
        /// </summary>
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// Order status (the list available to retrieve with getOrderStatusList)
        /// </summary>
        [JsonPropertyName("order_status_id")]
        public string OrderStatusId { get; set; }

        /// <summary>
        /// Date from which the order is in current status (unix time format)
        /// </summary>
        [JsonPropertyName("date_in_status")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateInStatus { get; set; }

        /// <summary>
        /// Date of order creation (in unix time format)
        /// </summary>
        [JsonPropertyName("date_add")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateAdd { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("orders")]
        public List<Order> Orders { get; set; }
    }
}