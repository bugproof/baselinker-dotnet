using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.BaseConnect;

/// <summary>
/// The method allows you to retrieve a list of all Base Connect integrations on this account.
/// </summary>
public class GetConnectIntegrations : IRequest<GetConnectIntegrations.Response>
{
    public class Integration
    {
        /// <summary>
        /// Connect integration ID
        /// </summary>
        [JsonPropertyName("connect_integration_id")]
        public int ConnectIntegrationId { get; set; }

        /// <summary>
        /// Integration name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Integration options
        /// </summary>
        [JsonPropertyName("settings")]
        public Dictionary<string, object> Settings { get; set; }
    }

    public class Response : ResponseBase
    {
        /// <summary>
        /// List of Base Connect integrations divided into own integrations (created on this account)
        /// and connected integrations (integrations to which this account has connected).
        /// </summary>
        [JsonPropertyName("integrations")]
        public List<Integration> Integrations { get; set; }
    }
}
