using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve a list of extra fields for a BaseLinker catalog.
/// </summary>
public class GetInventoryExtraFields : IRequest<GetInventoryExtraFields.Response>
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
        /// Type of additional field. Value 0 indicates a short field (max 200 characters).
        /// Value 1 means a long field (no limit of characters), where the value can be overwritten for specific integrations e.g. marketplace.
        /// </summary>
        [JsonPropertyName("kind")]
        public int Kind { get; set; }

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