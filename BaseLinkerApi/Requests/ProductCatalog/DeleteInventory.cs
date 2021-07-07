using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog
{
    /// <summary>
    /// The method allows you to delete a catalog from BaseLinker storage.
    /// </summary>
    public class DeleteInventory : IRequest
    {
        /// <summary>
        /// Catalog ID. The list of identifiers can be retrieved using the method getInventories.
        /// </summary>
        [JsonPropertyName("inventory_id")]
        public int InventoryId { get; set; }
    }
}