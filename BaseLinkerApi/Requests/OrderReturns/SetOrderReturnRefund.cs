using System;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows you to mark an order return as refunded. Note this method doesn't issue an actual money refund.
/// </summary>
public class SetOrderReturnRefund : IRequest
{
    /// <summary>
    /// Order return ID.
    /// </summary>
    [JsonPropertyName("return_id")]
    public int ReturnId { get; set; }

    /// <summary>
    /// The amount of the refund. The value changes the current refund in the order return (not added to the previous value).
    /// If the amount matches the order value, the order will be marked as refund.
    /// </summary>
    [JsonPropertyName("order_refund_done")]
    public double OrderRefundDone { get; set; }

    /// <summary>
    /// Refund date (unixtime format).
    /// </summary>
    [JsonPropertyName("refund_date")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset RefundDate { get; set; }

    /// <summary>
    /// Refund commentary.
    /// </summary>
    [JsonPropertyName("refund_comment")]
    public string RefundComment { get; set; }

    /// <summary>
    /// (optional) External refund identifier
    /// </summary>
    [JsonPropertyName("external_refund_id")]
    public string? ExternalRefundId { get; set; }
}
