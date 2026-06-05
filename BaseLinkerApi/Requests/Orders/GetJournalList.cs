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
            /// <summary>
            /// Event ID. API field: "id".
            /// </summary>
            [JsonPropertyName("id")]
            public int LogId { get; set; }

            /// <summary>
            /// Event type: 1 - Order creation, 2 - DOF download (order confirmation), 3 - Payment of the order,
            /// 4 - Removal of order/invoice/receipt, 5 - Merging the orders, 6 - Splitting the order,
            /// 7 - Issuing an invoice, 8 - Issuing a receipt, 9 - Package creation, 10 - Deleting a package,
            /// 11 - Editing delivery data, 12 - Adding a product to an order, 13 - Editing the product in the order,
            /// 14 - Removing the product from the order, 15 - Adding a buyer to a blacklist, 16 - Editing order data,
            /// 17 - Copying an order, 18 - Order status change, 19 - Invoice deletion, 20 - Receipt deletion,
            /// 21 - Editing invoice data, 22 - Package status change
            /// </summary>
            [JsonPropertyName("log_type")]
            public int LogType { get; set; }

            [JsonPropertyName("order_id")]
            public int OrderId { get; set; }

            /// <summary>
            /// Additional information, depending on the event type, e.g.: 5 - ID of the merged order,
            /// 6 - ID of the new order created by the order separation, 7 - Invoice ID, 9 - Created parcel ID,
            /// 10 - Deleted parcel ID, 14 - Deleted product ID, 17 - Created order ID, 18 - Order status ID,
            /// 22 - Parcel ID with changed status
            /// </summary>
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