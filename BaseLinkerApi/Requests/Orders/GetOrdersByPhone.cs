using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to search for orders related to the given phone number. This function is intended for use in caller recognition programs.
/// </summary>
public class GetOrdersByPhone : IRequest<GetOrdersByPhone.Response>
{
    [JsonPropertyName("phone")]
    public string Phone { get; set; }

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
            
        /// <summary>
        /// Delivery address - name and surname
        /// </summary>
        [JsonPropertyName("delivery_fullname")]
        public string DeliveryFullname { get; set; }
            
        /// <summary>
        /// Delivery address - company
        /// </summary>
        [JsonPropertyName("delivery_company")]
        public string DeliveryCompany { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("orders")]
        public List<Order> Orders { get; set; }
    }
}