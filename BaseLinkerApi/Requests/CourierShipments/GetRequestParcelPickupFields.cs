using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// The method allows you to retrieve additional fields for a parcel pickup request.
/// </summary>
public class GetRequestParcelPickupFields : IRequest<GetRequestParcelPickupFields.Response>
{
    [JsonPropertyName("courier_code")]
    public string CourierCode { get; set; }
    
    public class RequestParcelPickupField
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    
        [JsonPropertyName("name")]
        public string Name { get; set; }
    
        [JsonPropertyName("type")]
        public string Type { get; set; }
    
        [JsonPropertyName("desc")]
        public string? Desc { get; set; }
        
        /// <summary>
        /// List of available options (appears for select, checkbox).
        /// </summary>
        [JsonPropertyName("options")] 
        public Dictionary<string, string>? Options { get; set; }

        /// <summary>
        /// Default value for a field
        /// </summary>
        [JsonPropertyName("value")] 
        public string? Value { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("fields")] 
        public List<RequestParcelPickupField> Fields { get; set; }
    }
}