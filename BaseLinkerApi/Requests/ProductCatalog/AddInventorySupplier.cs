using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to add a new supplier or update an existing one in BaseLinker storage.
/// </summary>
public class AddInventorySupplier : IRequest<AddInventorySupplier.Response>
{
    /// <summary>
    /// (optional) Supplier identifier. If provided, the existing supplier will be updated.
    /// </summary>
    [JsonPropertyName("supplier_id")]
    public int? SupplierId { get; set; }

    /// <summary>
    /// Supplier name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Source of product cost for this supplier. Available values: "cost" (Product cost at the supplier), or price group ID.
    /// Price group ids can be retrieved from the method getInventoryPriceGroups.
    /// </summary>
    [JsonPropertyName("take_product_cost_from")]
    public string TakeProductCostFrom { get; set; }

    /// <summary>
    /// Source of product code for this supplier. Available values: "sku" (Product SKU), "ean" (Product EAN),
    /// "code" (Product code at the supplier), or extra field ID. Extra field ids can be retrieved from the method getInventoryExtraFields.
    /// </summary>
    [JsonPropertyName("take_product_code_from")]
    public string TakeProductCodeFrom { get; set; }

    /// <summary>
    /// (optional) Supplier address
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// (optional) Supplier postal code
    /// </summary>
    [JsonPropertyName("postcode")]
    public string? Postcode { get; set; }

    /// <summary>
    /// (optional) Supplier city
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// (optional) Supplier phone number
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// (optional) Supplier email address
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// (optional) Additional email addresses for correspondence
    /// </summary>
    [JsonPropertyName("email_copy_to")]
    public string? EmailCopyTo { get; set; }

    /// <summary>
    /// (optional) Default supplier currency (e.g. EUR, USD)
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// (optional) Supplier tax identification number
    /// </summary>
    [JsonPropertyName("tax_no")]
    public string? TaxNo { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// Created or updated supplier identifier
        /// </summary>
        [JsonPropertyName("supplier_id")]
        public int SupplierId { get; set; }
    }
}
