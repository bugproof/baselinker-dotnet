using System;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.BaseConnect;

/// <summary>
/// The method allows you to set new trade credit limit for chosen contractor.
/// </summary>
public class SetConnectContractorCreditLimit : IRequest<SetConnectContractorCreditLimit.Response>
{
    /// <summary>
    /// Contractor ID
    /// </summary>
    [Obsolete("Deprecated (changelog 2026-02-16). Use ConnectContractorId instead.")]
    [JsonPropertyName("contractor_id")]
    public int? ContractorId { get; set; }

    /// <summary>
    /// Contractor ID
    /// </summary>
    [JsonPropertyName("connect_contractor_id")]
    public int ConnectContractorId { get; set; }

    /// <summary>
    /// New limit value
    /// </summary>
    [JsonPropertyName("new_limit")]
    public double NewLimit { get; set; }

    /// <summary>
    /// Message shown in trade credit history
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// New trade credit limit value (formatted with currency)
        /// </summary>
        [JsonPropertyName("new_limit_set")]
        public string NewLimitSet { get; set; }
    }
}
