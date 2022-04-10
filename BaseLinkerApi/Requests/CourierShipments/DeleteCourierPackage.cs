using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// The method allows you to delete a previously created shipment. The method removes the shipment from the BaseLinker system and from the courier system if the courier API allows it
/// </summary>
public class DeleteCourierPackage : IRequest
{
    /// <summary>
    /// Courier code
    /// </summary>
    [JsonPropertyName("courier_code")]
    public string CourierCode { get; set; }

    /// <summary>
    /// Shipment ID, optional if package_number is provided
    /// </summary>
    [JsonPropertyName("package_id")]
    public int? PackageId { get; set; }

    /// <summary>
    /// Shipping number (consignment number), optional if package_id was provided
    /// </summary>
    [JsonPropertyName("package_number")]
    public string? PackageNumber { get; set; }

    /// <summary>
    /// (optional, false by default) Forcing a shipment to be removed from BaseLinker database in the case of an error with the removal of the shipment in the courier API.
    /// </summary>
    [JsonPropertyName("force_delete")]
    public bool? ForceDelete { get; set; }
}