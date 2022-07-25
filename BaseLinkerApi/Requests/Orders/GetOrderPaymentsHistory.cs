using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to retrieve payment history for a selected order, including an external payment identifier from the payment gateway.
/// One order can have multiple payment history entries, caused by surcharges, order value changes, manual payment editing
/// </summary>
public class GetOrderPaymentsHistory : IRequest<GetOrderPaymentsHistory.Response>
{
    /// <summary>
    /// Order Identifier from BaseLinker order manager
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// (optional, false by default) Download full payment history, including order value change entries, manual order payment edits.
    /// False by default - only returns entries containing an external payment identifier (most commonly used)
    /// </summary>
    [JsonPropertyName("show_full_history")]
    public bool? ShowFullHistory { get; set; }
        
    public class Payment
    {
        /// <summary>
        /// Total amount paid before the given change
        /// </summary>
        [JsonPropertyName("paid_before")]
        public decimal PaidBefore { get; set; }

        /// <summary>
        /// Total amount paid after the change
        /// </summary>
        [JsonPropertyName("paid_after")]
        public decimal PaidAfter { get; set; }

        [JsonPropertyName("total_price")]
        public decimal TotalPrice { get; set; }

        [JsonPropertyName("date")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("external_payment_id")]
        public string ExternalPaymentId { get; set; }
        
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("payments")]
        public List<Payment> Payments { get; set; }
    }
}