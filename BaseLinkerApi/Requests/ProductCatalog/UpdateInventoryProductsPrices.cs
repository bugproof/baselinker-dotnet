using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

public class UpdateInventoryProductsPrices : IRequest<UpdateInventoryProductsPrices.Response>
{
    [JsonPropertyName("inventory_id")]
    public int InventoryId { get; set; }

    [JsonPropertyName("products")]
    public Dictionary<string, Dictionary<string, decimal>> ProductPrices { get; set; }

    public class Response : ResponseBase
    {
        [JsonPropertyName("counter")]
        public int Counter { get; set; }
            
        [JsonPropertyName("warnings")]
        public Dictionary<string, string> Warnings { get; set; }
    }
}