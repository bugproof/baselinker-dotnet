using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// The method allows you to retrieve the history of the status list of the given shipments. Maximum 100 shipments at a time
/// </summary>
public class GetCourierPackagesStatusHistory : IRequest<GetCourierPackagesStatusHistory.Response>
{
    /// <summary>
    /// An array with a list of parcel IDs.
    /// </summary>
    [JsonPropertyName("package_ids")]
    public List<int> PackageIds { get; set; }
        
    public class PackagesStatusHistory
    {
        [JsonPropertyName("tracking_status_date")]
        public string TrackingStatusDate { get; set; }

        [JsonPropertyName("courier_status_code")]
        public string CourierStatusCode { get; set; }

        [JsonPropertyName("tracking_status")]
        public string TrackingStatus { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("packages_history")]
        public Dictionary<string, PackagesStatusHistory> PackagesHistory { get; set; }
    }
}