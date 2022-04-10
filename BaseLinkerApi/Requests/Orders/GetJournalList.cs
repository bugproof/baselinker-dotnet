using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to download a list of order events.
/// </summary>
public class GetJournalList : IRequest<GetJournalList.Response>
{
    [JsonPropertyName("last_log_id")]
    public int LastLogId { get; set; }

    [JsonPropertyName("logs_types")]
    public List<int> LogsTypes { get; set; }
        
    [JsonPropertyName("order_id")]
    public int? OrderId { get; set; }
        
    public class Response : ResponseBase
    {
        public class Log
        {
            [JsonPropertyName("log_id")]
            public int LogId { get; set; }

            [JsonPropertyName("log_type")]
            public int LogType { get; set; }

            [JsonPropertyName("order_id")]
            public int OrderId { get; set; }

            [JsonPropertyName("object_id")]
            public int ObjectId { get; set; }

            [JsonPropertyName("date")]
            [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
            public DateTimeOffset Date { get; set; }
        }
            
        [JsonPropertyName("logs")]
        public List<Log> Logs { get; set; }
    }
}