using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows you to retrieve payment history for a selected order return, including an external payment identifier from the payment gateway.
/// One order can have multiple payment history entries, caused by surcharges, order value changes, manual payment editing.
/// </summary>
public class GetOrderReturnPaymentsHistory : IRequest<GetOrderReturnPaymentsHistory.Response>
{
    /// <summary>
    /// Order return identifier.
    /// </summary>
    [JsonPropertyName("return_id")]
    public int ReturnId { get; set; }

    /// <summary>
    /// (optional, false by default) Download full payment history, including order value change entries, manual order payment edits.
    /// False by default - only returns entries containing an external payment identifier (most commonly used).
    /// </summary>
    [JsonPropertyName("show_full_history")]
    public bool? ShowFullHistory { get; set; }

    public class Payment
    {
        /// <summary>
        /// Total amount paid before the given change
        /// </summary>
        [JsonPropertyName("paid_before")]
        public double PaidBefore { get; set; }

        /// <summary>
        /// Total amount paid after the change
        /// </summary>
        [JsonPropertyName("paid_after")]
        public double PaidAfter { get; set; }

        /// <summary>
        /// Total order price
        /// </summary>
        [JsonPropertyName("total_price")]
        public double TotalPrice { get; set; }

        /// <summary>
        /// The currency
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// External payment identifier
        /// </summary>
        [JsonPropertyName("external_payment_id")]
        public string ExternalPaymentId { get; set; }

        /// <summary>
        /// Date of change record (unix time format)
        /// </summary>
        [JsonPropertyName("date")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset Date { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("payments")]
        public List<Payment> Payments { get; set; }
    }
}
