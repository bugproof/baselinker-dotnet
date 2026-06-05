using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.Crm;

/// <summary>
/// The method allows you to remove a CRM client. Orders previously associated with the deleted client are not affected.
/// </summary>
public class DeleteCrmClient : IRequest
{
    /// <summary>
    /// ID of the CRM client to delete.
    /// </summary>
    [JsonPropertyName("crm_client_id")]
    public int CrmClientId { get; set; }
}
