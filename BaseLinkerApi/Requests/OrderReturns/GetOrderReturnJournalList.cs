using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows you to download a list of return events from the last 3 days.
/// </summary>
public class GetOrderReturnJournalList : IRequest<GetOrderReturnJournalList.Response>
{
    /// <summary>
    /// Log ID number from which the logs are to be retrieved
    /// </summary>
    [JsonPropertyName("last_log_id")]
    public int LastLogId { get; set; }

    /// <summary>
    /// Event ID List
    /// </summary>
    [JsonPropertyName("logs_types")]
    public List<int> LogsTypes { get; set; }

    /// <summary>
    /// Return ID number
    /// </summary>
    [JsonPropertyName("return_id")]
    public int? ReturnId { get; set; }

    public class Log
    {
        /// <summary>
        /// Event ID
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Return identifier
        /// </summary>
        [JsonPropertyName("return_id")]
        public int ReturnId { get; set; }

        /// <summary>
        /// Event type: 1 - Return creation, 2 - Return accepted, 3 - Return completed, 4 - Return canceled,
        /// 5 - Return refunded, 6 - Editing return delivery data, 7 - Adding a product to a return,
        /// 8 - Editing a product in the return, 9 - Removing a product from the return, 10 - Editing return data,
        /// 11 - Return status change, 12 - Return item status change
        /// </summary>
        [JsonPropertyName("log_type")]
        public int LogType { get; set; }

        /// <summary>
        /// Additional information, depending on the event type: 9 - Deleted product ID, 14 - Created return parcel ID, 15 - Deleted return parcel ID
        /// </summary>
        [JsonPropertyName("object_id")]
        public int ObjectId { get; set; }

        /// <summary>
        /// Event date
        /// </summary>
        [JsonPropertyName("date")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset Date { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("logs")]
        public List<Log> Logs { get; set; }
    }
}
