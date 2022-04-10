using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve a list of warehouses available in BaseLinker catalogues. The method also returns information about the warehouses created automatically for the purpose of keeping external stocks (shops, wholesalers etc.)
/// </summary>
public class GetInventoryWarehouses : IRequest<GetInventoryWarehouses.Response>
{
    public class Warehouse
    {
        /// <summary>
        /// Warehouse type. One of the following values: [bl|shop|warehouse].
        /// </summary>
        [JsonPropertyName("warehouse_type")]
        public string WarehouseType { get; set; }

        /// <summary>
        /// Warehouse identifier
        /// </summary>
        [JsonPropertyName("warehouse_id")]
        public int WarehouseId { get; set; }

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
        /// Is manual stock editing permitted. A false value means that you can only edit your stock through the API.
        /// </summary>
        [JsonPropertyName("stock_edition")]
        public bool StockEdition { get; set; }

        /// <summary>
        /// Is this warehouse a default warehouse
        /// </summary>
        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("warehouses")]
        public List<Warehouse> Warehouses { get; set; }
    }
}