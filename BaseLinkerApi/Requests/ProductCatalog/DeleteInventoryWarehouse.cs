using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to remove the warehouse available in BaseLinker catalogues. The method does not allow to remove warehouses created automatically for the purpose of keeping external stocks of shops, wholesalers etc.
/// </summary>
public class DeleteInventoryWarehouse : IRequest
{
    /// <summary>
    /// ID of the warehouse
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public int WarehouseId { get; set; }
}