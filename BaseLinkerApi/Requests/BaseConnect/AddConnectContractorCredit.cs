using System;
using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.BaseConnect;

/// <summary>
/// The method allows you to add a trade credit entry for chosen contractor in Base Connect.
/// </summary>
[Obsolete("Deprecated (changelog 2025-10-21). It will do nothing. Use SetConnectContractorCreditLimit instead.")]
public class AddConnectContractorCredit : IRequest
{
    /// <summary>
    /// Contractor ID
    /// </summary>
    [JsonPropertyName("connect_contractor_id")]
    public int ConnectContractorId { get; set; }

    /// <summary>
    /// Trade credit amount
    /// </summary>
    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    /// <summary>
    /// Trade credit note
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }
}
