using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to download order statuses created by the customer in the BaseLinker order manager.
/// </summary>
public class GetOrderStatusList : IRequest<GetOrderStatusList.Response>
{
    public class Status
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_for_customer")]
        public string NameForCustomer { get; set; }
        
        /// <summary>
        /// status color in hex
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