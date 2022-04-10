using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// The method allows you to download a shipping label (consignment) for a selected shipment.
/// </summary>
public class GetLabel : IRequest<GetLabel.Response>
{
    [JsonPropertyName("courier_code")]
    public string CourierCode { get; set; }

    /// <summary>
    /// Shipment ID, optional if package_number was provided
    /// </summary>
    [JsonPropertyName("package_id")]
    public int? PackageId { get; set; }
        
    /// <summary>
    /// Shipping number (consignment number), optional if PackageId was provided
    /// </summary>
    [JsonPropertyName("package_number")]
    public string PackageNumber { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// Label file extension (pdf, html, gif, png, epl, zpl, dpl).
        /// </summary>
        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        /// <summary>
        /// Label encoded with base64 algorithm.
        /// </summary>
        [JsonPropertyName("label")]
        public byte[] Label { get; set; } // technically should deserialize correctly... https://github.com/dotnet/runtime/issues/29299
    }
}