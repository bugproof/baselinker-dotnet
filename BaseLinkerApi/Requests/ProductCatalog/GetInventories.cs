using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve a list of catalogs available in the BaseLinker storage.
/// </summary>
public class GetInventories : IRequest<GetInventories.Response>
{
    public class Inventory
    {
        [JsonPropertyName("inventory_id")]
        public int InventoryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("languages")]
        public List<string> Languages { get; set; }

        [JsonPropertyName("default_language")]
        public string DefaultLanguage { get; set; }

        [JsonPropertyName("price_groups")]
        public List<int> PriceGroups { get; set; }

        [JsonPropertyName("default_price_group")]
        public int DefaultPriceGroup { get; set; }

        [JsonPropertyName("warehouses")]
        public List<string> Warehouses { get; set; }

        [JsonPropertyName("default_warehouse")]
        public string DefaultWarehouse { get; set; }

        [JsonPropertyName("reservations")]
        public bool Reservations { get; set; }

        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("inventories")]
        public List<Inventory> Inventories { get; set; }
    }
}