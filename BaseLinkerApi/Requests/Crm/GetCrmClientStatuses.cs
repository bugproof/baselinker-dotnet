using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Crm;

/// <summary>
/// The method allows you to retrieve CRM client statuses created by the user in the order manager.
/// </summary>
public class GetCrmClientStatuses : IRequest<GetCrmClientStatuses.Response>
{
    public class Status
    {
        /// <summary>
        /// Status ID.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Status name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Status color (hex, e.g. #1C8752).
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; set; }

        /// <summary>
        /// Status group ID. The group details can be retrieved with getCrmClientStatusGroups method.
        /// </summary>
        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        /// <summary>
        /// Whether this is the primary (default) status (0 or 1).
        /// </summary>
        [JsonPropertyName("is_primary")]
        public int IsPrimary { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("statuses")]
        public List<Status> Statuses { get; set; }
    }
}
