using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// <para>The method returns a list of integrations where text values in the catalog can be overwritten.</para>
/// <para>The returned data contains a list of accounts for each integration and a list of languages supported by the integration</para>
/// </summary>
public class GetInventoryIntegrations : IRequest<GetInventoryIntegrations.Response>
{
    /// <summary>
    /// Catalog ID. The list of identifiers can be retrieved by the getInventories method (inventory_id field).
    /// </summary>
    [JsonPropertyName("inventory_id")]
    public int InventoryId { get; set; }
        
    public class Integration
    {
        [JsonPropertyName("langs")]
        public List<string> Langs { get; set; }

        [JsonPropertyName("accounts")]
        public Dictionary<int, string> Accounts { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("integrations")]
        public Dictionary<string, Integration> Integrations { get; set; }
    }
}