using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to add a category to the BaseLinker catalog. Adding a category with the same identifier again, updates the previously saved category
/// </summary>
public class AddInventoryCategory : IRequest<AddInventoryCategory.Response>
{
    /// <summary>
    /// <para>Catalog ID. The list of identifiers can be retrieved by the getInventories method (inventory_id field).</para>
    /// <para>To add a category available for all catalogs created in BaseLinker, this field should be omitted.</para>
    /// </summary>
    [JsonPropertyName("inventory_id")]
    public int? InventoryId { get; set; }
            
    /// <summary>
    /// The category identifier to be provided for updates. Should be left blank when creating a new category.
    /// </summary>
    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; }
            
    /// <summary>
    /// Category name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// <para>The parent category identifier obtained previously at the output of the addCategory method.</para>
    /// <para>Categories should be added starting from the hierarchy root so that the child is always added after the parent (you need to know the parent ID to add the child).</para>
    /// <para>For the top level category, 0 should be given as parent_id.</para>
    /// </summary>
    [JsonPropertyName("parent_id")]
    public int ParentId { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// <para>Number of a category added or updated in BaseLinker storage.</para>
        /// <para>In an external application you should create a link between the internal number and the number received here.</para>
        /// <para>It will later be used to update the added category.</para>
        /// <para>This number is also used in addProducts and deleteCategory methods.</para>
        /// </summary>
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
    }
}