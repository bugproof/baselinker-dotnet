using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// <para>The method allows you to remove categories from BaseLinker warehouse.</para>
/// <para>Along with the category, the products contained therein are removed (however, this does not apply to products in subcategories).</para>
/// <para>The subcategories will be changed to the highest level categories.</para>
/// </summary>
public class DeleteInventoryCategory : IRequest
{
    /// <summary>
    /// The number of the category to be removed in the BaseLinker storage.
    /// </summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }
}