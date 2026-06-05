using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.BaseConnect;

/// <summary>
/// The method allows you to add a trade credit entry for chosen contractor in Base Connect.
/// </summary>
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
