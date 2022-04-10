using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to add the BaseLinker catalos. Adding a catalog with the same identifier again will cause updates of the previously saved catalog.
/// </summary>
public class AddInventory : IRequest<AddInventory.Response>
{
    /// <summary>
    /// Catalog ID. The list of identifiers can be retrieved using the method getInventories.
    /// </summary>
    [JsonPropertyName("inventory_id")]
    public int? InventoryId { get; set; }
        
    /// <summary>
    /// Catalog name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Catalog description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// An array of languages available in the catalogue.
    /// </summary>
    [JsonPropertyName("languages")]
    public List<string> Languages { get; set; }

    /// <summary>
    /// Default catalogue language. Must be included in the "languages" parameter. (2 char pl, en...)
    /// </summary>
    [JsonPropertyName("default_language")]
    public string DefaultLanguage { get; set; }

    /// <summary>
    /// An array of price group identifiers available in the catalogue. The list of price group identifiers can be downloaded using the getInventoryPriceGroups method
    /// </summary>
    [JsonPropertyName("price_groups")]
    public List<int> PriceGroups { get; set; }

    /// <summary>
    /// ID of the price group default for the catalogue. The identifier must be included in the "price_groups" parameter.
    /// </summary>
    [JsonPropertyName("default_price_group")]
    public int DefaultPriceGroup { get; set; }

    /// <summary>
    /// An array of warehouse identifiers available in the catalogue. The list of warehouse identifiers can be retrieved using the getInventoryWarehouses API method. The format of the identifier should be as follows: "[type:bl|shop|warehouse]_[id:int]". (e.g. "shop_2445")
    /// </summary>
    [JsonPropertyName("warehouses")]
    public List<string> Warehouses { get; set; }

    /// <summary>
    /// Identifier of the warehouse default for the catalogue. The identifier must be included in the "warehouses" parameter.
    /// </summary>
    [JsonPropertyName("default_warehouse")]
    public string DefaultWarehouse { get; set; }

    /// <summary>
    /// Does this catalogue support reservations
    /// </summary>
    [JsonPropertyName("reservations")]
    public bool Reservations { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// Catalog ID. The list of identifiers can be retrieved using the method getInventories.
        /// </summary>
        [JsonPropertyName("inventory_id")]
        public int InventoryId { get; set; }
    }
}