using System;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// The method allows you to enter the shipping number and the name of the courier to the order (function used only to add shipments created outside BaseLinker)
/// </summary>
public class CreatePackageManual : IRequest<CreatePackageManual.Response>
{
    /// <summary>
    /// Order identifier
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// Courier code (courier code retrieved with getCourierList or custom courier name)
    /// </summary>
    [JsonPropertyName("courier_code")]
    public string CourierCode { get; set; }

    /// <summary>
    /// Shipping number (consignment number)
    /// </summary>
    [JsonPropertyName("package_number")]
    public string PackageNumber { get; set; }

    /// <summary>
    /// Date of dispatch (unix time format)
    /// </summary>
    [JsonPropertyName("pickup_date")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset PickupDate { get; set; }
    
    /// <summary>
    /// (optional, false by default) Marks package as return shipment
    /// </summary>
    [JsonPropertyName("return_shipment")]
    public bool ReturnShipment { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// Shipment ID
        /// </summary>
        [JsonPropertyName("package_id")]
        public int PackageId { get; set; }

        /// <summary>
        /// Shipping number (consignment number)
        /// </summary>
        [JsonPropertyName("package_number")]
        public string PackageNumber { get; set; }
    }
}