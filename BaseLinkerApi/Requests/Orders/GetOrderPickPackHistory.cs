using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to retrieve pick pack history for a selected order.
/// </summary>
public class GetOrderPickPackHistory : IRequest<GetOrderPickPackHistory.Response>
{
    /// <summary>
    /// Order Identifier from BaseLinker order manager
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// (optional) Event type you want to retrieve. Available values:
    /// 1 - Reservation of an order for products collecting, 2 - Picking products started, 3 - Picking products cancelled,
    /// 4 - Products picking status changed: in progress, 5 - Products picking status changed: finished,
    /// 6 - Products picking status changed: error, 7 - Reservation of an order for products packing,
    /// 8 - Packing products started, 9 - Packing products cancelled, 10 - Products packing status changed: in progress,
    /// 11 - Products packing status changed: finished, 12 - Products packing status changed: error,
    /// 13 - Products photo initialized, 14 - Products photo taken, 15 - Products photo deleted,
    /// 16 - Error when trying to save products photo, 17 - Error when trying to save product image: image size too large,
    /// 18 - Package photo received via Base Connect
    /// </summary>
    [JsonPropertyName("action_type")]
    public int? ActionType { get; set; }

    public class Response : ResponseBase
    {
        public class HistoryEntry
        {
            /// <summary>
            /// Action type. See <see cref="GetOrderPickPackHistory.ActionType"/> for the list of available values.
            /// </summary>
            [JsonPropertyName("action_type")]
            public int ActionType { get; set; }

            /// <summary>
            /// Name of the profile performing the change
            /// </summary>
            [JsonPropertyName("profile_id")]
            public string ProfileId { get; set; }

            /// <summary>
            /// Id of the packing station
            /// </summary>
            [JsonPropertyName("station_id")]
            public int StationId { get; set; }

            /// <summary>
            /// Id of cart assigned to order
            /// </summary>
            [JsonPropertyName("cart_id")]
            public int CartId { get; set; }

            /// <summary>
            /// Date of history entry (unix time format)
            /// </summary>
            [JsonPropertyName("entry_date")]
            [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
            public DateTimeOffset EntryDate { get; set; }
        }

        [JsonPropertyName("history")]
        public List<HistoryEntry> History { get; set; }
    }
}
