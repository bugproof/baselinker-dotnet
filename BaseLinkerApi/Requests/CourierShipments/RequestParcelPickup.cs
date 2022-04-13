using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.CourierShipments;

public class RequestParcelPickup : IRequest<RequestParcelPickup.Response>
{
    [JsonPropertyName("courier_code")]
    public string CourierCode { get; set; }

    /// <summary>
    /// Array of shipments ID, optional if package_numbers was provided
    /// </summary>
    [JsonPropertyName("package_ids")]
    public List<string>? PackageIds { get; set; }
    
    /// <summary>
    /// Array of shipments number (consignment number), optional if package_ids was provided
    /// </summary>
    [JsonPropertyName("package_numbers")]
    public List<string>? PackageNumbers { get; set; }
    
    /// <summary>
    /// Courier API account id for the courier accounts retrieved from the request getCourierAccounts
    /// </summary>
    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }

    public class Field
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
    
    /// <summary>
    /// List of form fields retrieved from the request getRequestParcelPickupFields
    /// </summary>
    [JsonPropertyName("fields")] 
    public List<Field> Fields { get; set; }
    
    public class Response : ResponseBase
    {
        /// <summary>
        /// The parcel pickup number provided by the courier API
        /// </summary>
        [JsonPropertyName("pickup_number")]
        public string PickupNumber { get; set; }
    }
}