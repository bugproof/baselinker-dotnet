using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

// TODO: test this.. might be wrong
/// <summary>
/// The method returns a list of product text fields that can be overwritten for specific integration.
/// </summary>
public class GetInventoryAvailableTextFieldKeys : IRequest<GetInventoryAvailableTextFieldKeys.Response>
{
    /// <summary>
    /// Catalog ID. The list of identifiers can be retrieved by the getInventories method (inventory_id field).
    /// </summary>
    [JsonPropertyName("inventory_id")]
    public int InventoryId { get; set; }
        
    public class Response : ResponseBase
    {
        // TODO: this needs to be tested...
        /// <summary>
        /// A list containing product text fields, where the key is the code of the text field and the value is the text field name
        /// </summary>
        [JsonPropertyName("text_field_keys")]
        public Dictionary<string, string> TextFieldKeys { get; set; }
    }
}