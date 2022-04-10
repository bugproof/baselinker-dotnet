using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// The method allows you to retrieve the form fields for creating shipments for the selected courier.
/// </summary>
public class GetCourierFields : IRequest<GetCourierFields.Response>
{
    /// <summary>
    /// Courier code
    /// </summary>
    [JsonPropertyName("courier_code")]
    public string CourierCode { get; set; }
        
    public class Response : ResponseBase
    {
        public class Field
        {
            /// <summary>
            /// The field ID
            /// </summary>
            [JsonPropertyName("id")]
            public string Id { get; set; }

            /// <summary>
            /// The field name
            /// </summary>
            [JsonPropertyName("name")]
            public string Name { get; set; }

            /// <summary>
            /// Field type (available select, checkbox, text, date)
            /// </summary>
            [JsonPropertyName("type")]
            public string Type { get; set; }

            /// <summary>
            /// Additional field description
            /// </summary>
            [JsonPropertyName("desc")]
            public string Desc { get; set; }

            /// <summary>
            /// List of available options (appears for select, checkbox).
            /// </summary>
            [JsonPropertyName("options")]
            public Dictionary<string, string> Options { get; set; }

            /// <summary>
            /// List of additional fields that are available for the selected option.
            /// </summary>
            [JsonPropertyName("show_field")]
            public Dictionary<string, List<string>> ShowField { get; set; }

            /// <summary>
            /// Default value for a field
            /// </summary>
            [JsonPropertyName("value")]
            public string? Value { get; set; }
                
            /// <summary>
            /// If this value is not empty, it means that the field has dynamic options and in order to download the current options for a particular order, you should retrieve with the getCourierServices" request
            /// </summary>
            [JsonPropertyName("function")]
            public string? Function { get; set; }
        }
            
        public class PackageField
        {
            /// <summary>
            /// The field ID
            /// </summary>
            [JsonPropertyName("id")]
            public string Id { get; set; }

            /// <summary>
            /// The field name
            /// </summary>
            [JsonPropertyName("name")]
            public string Name { get; set; }

            /// <summary>
            /// Field type (available select, checkbox, text)
            /// </summary>
            [JsonPropertyName("type")]
            public string Type { get; set; }
        }
            
        /// <summary>
        /// Does the courier support multiple shipments (0/1).
        /// </summary>
        [JsonPropertyName("multi_packages")]
        public bool MultiPackages { get; set; }
            
        /// <summary>
        /// An array with a list of fields to create a shipment 
        /// </summary>
        [JsonPropertyName("fields")]
        public List<Field> Fields { get; set; }

        /// <summary>
        /// An array with a list of fields to create packages
        /// </summary>
        [JsonPropertyName("package_fields")]
        public List<PackageField> PackageFields { get; set; }
    }
}