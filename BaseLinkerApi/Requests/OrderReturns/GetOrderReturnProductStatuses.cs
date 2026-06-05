using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method returns a list of order return item statuses. Values of those fields can be set with method setOrderReturnFields.
/// </summary>
public class GetOrderReturnProductStatuses : IRequest<GetOrderReturnProductStatuses.Response>
{
    public class Status
    {
        /// <summary>
        /// ID of the order return item status
        /// </summary>
        [JsonPropertyName("status_id")]
        public int StatusId { get; set; }

        /// <summary>
        /// Order return item status name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("order_return_product_statuses")]
        public List<Status> OrderReturnProductStatuses { get; set; }
    }
}
