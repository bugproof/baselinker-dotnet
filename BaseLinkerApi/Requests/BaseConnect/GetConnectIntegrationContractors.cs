using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.BaseConnect;

/// <summary>
/// The method allows you to retrieve a list of contractors connected to the selected Base Connect integration.
/// </summary>
public class GetConnectIntegrationContractors : IRequest<GetConnectIntegrationContractors.Response>
{
    [JsonPropertyName("token_id")]
    public int TokenId { get; set; }

    public class Contractor
    {
        /// <summary>
        /// Contractor ID
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Contractor name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Contractor credit summary data
        /// </summary>
        [JsonPropertyName("credit_data")]
        public Dictionary<string, object> CreditData { get; set; }

        /// <summary>
        /// Contractor options
        /// </summary>
        [JsonPropertyName("settings")]
        public Dictionary<string, object> Settings { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("contractors")]
        public List<Contractor> Contractors { get; set; }
    }
}
