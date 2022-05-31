using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method returns extra fields defined for the orders.
/// Values of those fields can be set with method setOrderFields.
/// In order to retrieve values of those fields set parameter include_custom_extra_fields in method getOrders
/// </summary>
public class GetOrderExtraFields : IRequest<GetOrderExtraFields.Response>
{
    public class ExtraField
    {
        /// <summary>
        /// ID of the extra field
        /// </summary>
        [JsonPropertyName("extra_field_id")]
        public int ExtraFieldId { get; set; }

        /// <summary>
        /// Field name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Editor type. The following values are available: text, number, select, checkbox, radio, date, file.
        /// </summary>
        [JsonPropertyName("editor_type")]
        public string EditorType { get; set; }

        /// <summary>
        /// (optional) An array of values available for a given additional field. Applicable to select, checkbox and radio editors.
        /// </summary>
        [JsonPropertyName("options")]
        public List<string> Options { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("extra_fields")] public List<ExtraField> ExtraFields { get; set; }
    }
}