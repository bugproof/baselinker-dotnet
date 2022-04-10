using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// <para>The method allows you to add a new warehouse available in BaseLinker catalogues.</para>
/// <para>Adding a warehouse with the same identifier again will cause updates of the previously saved warehouse.</para>
/// <para>The method does not allow editing warehouses created automatically for the purpose of keeping external stocks of shops, wholesalers etc.</para>
/// <para>Such warehouse may be later used in addInventory method.</para>
/// </summary>
public class AddInventoryWarehouse : IRequest<AddInventoryWarehouse.Response>
{
    /// <summary>
    /// ID of the warehouse
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public int? WarehouseId { get; set; }
            
    /// <summary>
    /// Warehouse name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Warehouse description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// Is manual editing of stocks permitted. A false value means that you can only edit your stock through the API.
    /// </summary>
    [JsonPropertyName("stock_edition")]
    public bool StockEdition { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// The ID of created or updated warehouse
        /// </summary>
        [JsonPropertyName("warehouse_id")]
        public int WarehouseId { get; set; }
    }
}