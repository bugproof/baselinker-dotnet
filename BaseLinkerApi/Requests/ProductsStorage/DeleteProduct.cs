using System;
using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.ProductsStorage;

/// <summary>
/// The method allows you to remove the product from BaseLinker storage.
/// </summary>
[Obsolete]
public class DeleteProduct : IRequest
{
    [JsonPropertyName("storage_id")]
    public string StorageId { get; set; }

    [JsonPropertyName("product_id")]
    public string ProductId { get; set; }
}