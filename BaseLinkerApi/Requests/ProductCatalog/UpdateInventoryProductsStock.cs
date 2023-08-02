using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows to update stocks of products (and/or their variants) in BaseLinker catalog. Maximum 1000 products at a time.
/// </summary>
public class UpdateInventoryProductsStock : IRequest<UpdateInventoryProductsStock.Response>
{
    /// <summary>
    /// Catalog ID. The list of identifiers can be retrieved using the method <b>getInventories</b>. 
    /// </summary>
    [JsonPropertyName("inventory_id")]
    public int InventoryId { get; set; }

    /// <summary>
    /// An array of products, where the key is a product ID and the value is a list of stocks. When determining the variant stock, provide variant ID as a product ID.
    /// In the stocks array the key should be the warehouse ID and the value - stock for that warehouse. The format of the warehouse identifier should be as follows: "[type:bl|shop|warehouse]_[id:int]". (e.g. "bl_123"). The list of warehouse identifiers can be retrieved using the getInventoryWarehousesmethod.
    /// Stocks cannot be assigned to the warehouses created automatically for purposes of keeping external stocks (shops, wholesalers, etc.).
    /// </summary>
    [JsonPropertyName("products")]
    public Dictionary<string, Dictionary<string, int>> ProductStocks { get; set; }

    public class Response : ResponseBase
    {
        [JsonPropertyName("counter")]
        public int Counter { get; set; }

        [JsonPropertyName("warnings")]
        public Dictionary<string, string> Warnings { get; set; }
    }
}