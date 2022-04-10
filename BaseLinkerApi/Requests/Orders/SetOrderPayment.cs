using System;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to add a payment to the order.
/// </summary>
public class SetOrderPayment : IRequest
{
    /// <summary>
    /// Order ID number
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// The amount of the payment. The value changes the current payment in the order (not added to the previous value). If the amount matches the order value, the order will be marked as paid.
    /// </summary>
    [JsonPropertyName("payment_done")]
    public decimal PaymentDone { get; set; }

    /// <summary>
    /// Payment date unixtime.
    /// </summary>
    [JsonPropertyName("payment_date")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset PaymentDate { get; set; }

    /// <summary>
    /// Payments commentary.
    /// </summary>
    [JsonPropertyName("payment_comment")]
    public string PaymentComment { get; set; }
}