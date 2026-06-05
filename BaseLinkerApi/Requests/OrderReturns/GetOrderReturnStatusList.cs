using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows you to download order return statuses created by the customer in the BaseLinker order manager.
/// </summary>
public class GetOrderReturnStatusList : IRequest<GetOrderReturnStatusList.Response>
{
    public class Status
    {
        /// <summary>
        /// Status identifier
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Status name (basic)
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Long status name (displayed to the customer on the order page)
        /// </summary>
        [JsonPropertyName("name_for_customer")]
        public string NameForCustomer { get; set; }

        /// <summary>
        /// Status color in hex
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("statuses")]
        public List<Status> Statuses { get; set; }
    }
}
