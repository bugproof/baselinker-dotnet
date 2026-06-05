using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method returns extra fields defined for order returns. Values of those fields can be set with method setOrderReturnFields.
/// To retrieve values of those fields set parameter include_custom_extra_fields in method getOrderReturns.
/// </summary>
public class GetOrderReturnExtraFields : IRequest<GetOrderReturnExtraFields.Response>
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
        [JsonPropertyName("extra_fields")]
        public List<ExtraField> ExtraFields { get; set; }
    }
}
