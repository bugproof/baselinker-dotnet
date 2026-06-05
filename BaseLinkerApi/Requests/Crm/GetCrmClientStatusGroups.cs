using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Crm;

/// <summary>
/// The method allows you to retrieve the list of CRM client status groups.
/// </summary>
public class GetCrmClientStatusGroups : IRequest<GetCrmClientStatusGroups.Response>
{
    public class StatusGroup
    {
        /// <summary>
        /// Status group ID.
        /// </summary>
        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        /// <summary>
        /// Status group name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether this is the main (default) group (0 or 1).
        /// </summary>
        [JsonPropertyName("is_main_group")]
        public int IsMainGroup { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("status_groups")]
        public List<StatusGroup> StatusGroups { get; set; }
    }
}
