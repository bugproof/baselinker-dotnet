using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method returns a list of order return reasons. Values of those fields can be set with method setOrderReturnFields.
/// </summary>
public class GetOrderReturnReasonsList : IRequest<GetOrderReturnReasonsList.Response>
{
    public class ReturnReason
    {
        /// <summary>
        /// ID of the order return reason
        /// </summary>
        [JsonPropertyName("return_reason_id")]
        public int ReturnReasonId { get; set; }

        /// <summary>
        /// Order return reason name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("return_reasons")]
        public List<ReturnReason> ReturnReasons { get; set; }
    }
}
