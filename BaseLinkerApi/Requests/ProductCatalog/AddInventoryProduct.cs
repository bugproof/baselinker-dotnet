using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to add a new product to BaseLinker catalog. Entering the product with the ID updates previously saved product.
/// </summary>
public class AddInventoryProduct : IRequest<AddInventoryProduct.Response>
{
    public class Features
    {
        [JsonPropertyName("Cover")]
        public string Cover { get; set; }

        [JsonPropertyName("Pages")]
        public string Pages { get; set; }

        [JsonPropertyName("Language")]
        public string Language { get; set; }
    }

    public class Link
    {
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [JsonPropertyName("variant_id")]
        public int VariantId { get; set; }
    }
        
    /// <summary>
    /// Catalog ID. The list of identifiers can be retrieved using the method getInventories. (inventory_id field).
    /// </summary>
    [JsonPropertyName("inventory_id")]
    public int InventoryId { get; set; }

    /// <summary>
    /// Main product identifier, given only during the update. Should be left blank when creating a new product. The new product identifier is returned as a response to this method.
    /// </summary>
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }
        
    /// <summary>
    /// Product parent ID. To be provided only if the added/edited product is a variant of another product.
    /// </summary>
    [JsonPropertyName("parent_id")]
    public string? ParentId { get; set; }

    /// <summary>
    /// Is the given product a part of a bundle
    /// </summary>
    [JsonPropertyName("is_bundle")]
    public bool IsBundle { get; set; }
    
    /// <summary>
    /// Should be null when IsBundle is false
    /// </summary>
    [JsonPropertyName("bundle_products")]
    public Dictionary<string, int>? BundleProducts { get; set; }

    /// <summary>
    /// Product EAN number.
    /// </summary>
    [JsonPropertyName("ean")]
    public string Ean { get; set; }

    /// <summary>
    /// Product SKU number.
    /// </summary>
    [JsonPropertyName("sku")]
    public string Sku { get; set; }

    /// <summary>
    /// VAT tax rate (e.g. "20")
    /// </summary>
    [JsonPropertyName("tax_rate")]
    public double TaxRate { get; set; }

    /// <summary>
    /// Weight in kilograms.
    /// </summary>
    [JsonPropertyName("weight")]
    public double Weight { get; set; }

    /// <summary>
    /// Product height
    /// </summary>
    [JsonPropertyName("height")]
    public double Height { get; set; }

    /// <summary>
    /// Product width
    /// </summary>
    [JsonPropertyName("width")]
    public double Width { get; set; }

    /// <summary>
    /// Product length
    /// </summary>
    [JsonPropertyName("length")]
    public double Length { get; set; }

    /// <summary>
    /// Product star type. It takes from 0 to 5 values. 0 means no starring.
    /// </summary>
    [JsonPropertyName("star")]
    public int Star { get; set; }

    /// <summary>
    /// Product manufacturer ID. IDs can be retrieved with getInventoryManufacturers method.
    /// </summary>
    [JsonPropertyName("manufacturer_id")]
    public int ManufacturerId { get; set; }

    /// <summary>
    /// Product category ID (category must be previously created with addInventoryCategories) method.
    /// </summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    /// <summary>
    /// A list containing product prices, where the key is the price group ID and value is a product gross price for a given price group.
    /// The list of price groups can be retrieved with getInventoryPriceGroups method.
    /// </summary>
    [JsonPropertyName("prices")]
    public Dictionary<int, decimal> Prices { get; set; }

    /// <summary>
    /// A list containing product stocks, where the key is the warehouse ID and value is a product stock for a given warehouse.
    /// Warehouse ID should have this format: "bl_[id:int]" (eg. "bl_123").The list of warehouse IDs can be retrieved with getInventoryWarehouses method.
    /// Stocks cannot be assigned to the warehouses created automatically for purposes of keeping external stocks (shops, wholesalers, etc.).
    /// </summary>
    [JsonPropertyName("stock")]
    public Dictionary<string, int> Stock { get; set; }

    /// <summary>
    /// A list containing product locations where the key is the warehouse ID and value is a product location for a given warehouse, eg. "A-5-2".
    /// Warehouse ID should have this format: "[type:bl|shop|warehouse]_[id:int]" (eg. "bl_123").
    /// The list of warehouse IDs can be retrieved with getInventoryWarehouses method.
    /// </summary>
    [JsonPropertyName("locations")]
    public Dictionary<string, string> Locations { get; set; }

    /// <summary>
    /// A bit long... refer to the docs
    /// https://api.baselinker.com/index.php?method=addInventoryProduct
    /// </summary>
    [JsonPropertyName("text_fields")]
    public Dictionary<string, object> TextFields { get; set; }

    /// <summary>
    /// An array of product images (maximum 16). Each element of the array is a separate photo.
    /// You can submit a photo in binary format, or a link to the photo.
    /// In case of binary format, the photo should be coded in base64 and at the very beginning of the photo string the prefix "data:" should be provided.
    /// In case of link to the photo, the prefix "url:" must be given before the link. Example:
    /// images[0] = "url:http://adres.pl/zdjecie.jpg";
    /// images[1] = "data:4AAQSkZJRgABA[...]";
    /// </summary>
    [JsonPropertyName("images")]
    public List<string> Images { get; set; }

    /// <summary>
    /// An array containing product links to external warehouses (e.g. shops, wholesalers).
    /// Each element of the array is a list in which the key is the identifier of the external warehouse in the format "[type:shop|warehouse]_[id:int]". (e.g. "shop_2445").
    /// The warehouse identifiers can be retrieved with the getStoragesList method.
    /// The value is an array containing the fields listed below.
    /// </summary>
    [JsonPropertyName("links")]
    public Dictionary<string, Link> Links { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// <para>The number of an added or updated product in the BaseLinker catalogue.</para>
        /// <para>In an external application you should create a link between the internal number and the number received here.</para>
        /// <para>It will later be used to update the added product. This number will also be included in the order items in the getOrders function.</para>
        /// </summary>
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }
            
        /// <summary>
        /// An object with notes on adding a product (e.g. image errors or others that do not interrupt the request). Each object field informs about a separate error.
        /// </summary>
        [JsonPropertyName("warnings")]
        public object Warnings { get; set; }
    }
}