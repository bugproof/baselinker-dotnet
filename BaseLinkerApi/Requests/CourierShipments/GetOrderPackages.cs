using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// The method allows you to download shipments previously created for the selected order.
/// </summary>
public class GetOrderPackages : IRequest<GetOrderPackages.Response>
{
    /// <summary>
    /// Order identifier
    /// </summary>
    [JsonPropertyName("order_id")]
    public string OrderId { get; set; }

    public class Package
    {
        [JsonPropertyName("package_id")]
        public string PackageId { get; set; }

        [JsonPropertyName("courier_package_nr")]
        public string CourierPackageNr { get; set; }

        [JsonPropertyName("courier_inner_number")]
        public string CourierInnerNumber { get; set; }

        [JsonPropertyName("courier_code")]
        public string CourierCode { get; set; }

        [JsonPropertyName("courier_other_name")]
        public string CourierOtherName { get; set; }

        [JsonPropertyName("tracking_status_date")]
        public string TrackingStatusDate { get; set; }

        [JsonPropertyName("tracking_delivery_days")]
        public string TrackingDeliveryDays { get; set; }

        [JsonPropertyName("tracking_status")]
        public string TrackingStatus { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("packages")]
        public List<Package> Packages { get; set; }
    }
}