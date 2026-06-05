using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// Add new product to existing order return.
/// </summary>
public class AddOrderReturnProduct : IRequest<AddOrderReturnProduct.Response>
{
    /// <summary>
    /// Order return identifier. Field required. Other fields are optional.
    /// </summary>
    [JsonPropertyName("return_id")]
    public int ReturnId { get; set; }

    /// <summary>
    /// Type of product source storage (available values: "db" - BaseLinker internal inventory, "shop" - online shop storage, "warehouse" - the connected wholesaler)
    /// </summary>
    [JsonPropertyName("storage")]
    public string Storage { get; set; }

    /// <summary>
    /// The identifier of the storage (inventory/shop/warehouse) from which the product comes.
    /// </summary>
    [JsonPropertyName("storage_id")]
    public string StorageId { get; set; }

    /// <summary>
    /// Product identifier in BaseLinker or shop storage. Blank if the product number is not known.
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; }

    /// <summary>
    /// Product variant ID. Blank if the variant number is unknown.
    /// </summary>
    [JsonPropertyName("variant_id")]
    public string VariantId { get; set; }

    /// <summary>
    /// Listing ID number (if the order comes from ebay/allegro)
    /// </summary>
    [JsonPropertyName("auction_id")]
    public string AuctionId { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Product SKU number
    /// </summary>
    [JsonPropertyName("sku")]
    public string Sku { get; set; }

    /// <summary>
    /// Product EAN number
    /// </summary>
    [JsonPropertyName("ean")]
    public string Ean { get; set; }

    /// <summary>
    /// Product location
    /// </summary>
    [JsonPropertyName("location")]
    public string Location { get; set; }

    /// <summary>
    /// Product source warehouse identifier. Only applies to products from BaseLinker inventory.
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public int? WarehouseId { get; set; }

    /// <summary>
    /// The detailed product attributes, e.g. "Colour: blue" (Variant name)
    /// </summary>
    [JsonPropertyName("attributes")]
    public string Attributes { get; set; }

    /// <summary>
    /// Single item gross price
    /// </summary>
    [JsonPropertyName("price_brutto")]
    public double? PriceBrutto { get; set; }

    /// <summary>
    /// VAT tax rate e.g. "23"
    /// </summary>
    [JsonPropertyName("tax_rate")]
    public double? TaxRate { get; set; }

    /// <summary>
    /// Number of pieces
    /// </summary>
    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }

    /// <summary>
    /// Single piece weight
    /// </summary>
    [JsonPropertyName("weight")]
    public decimal? Weight { get; set; }

    /// <summary>
    /// Identifier of return item status. The list can be retrieved with getOrderReturnProductStatuses method.
    /// </summary>
    [JsonPropertyName("status_id")]
    public int? StatusId { get; set; }

    /// <summary>
    /// Identifier of return reason. The list can be retrieved with getOrderReturnReasonsList method.
    /// </summary>
    [JsonPropertyName("return_reason_id")]
    public int? ReturnReasonId { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// Identifier of the item added to the return.
        /// </summary>
        [JsonPropertyName("order_return_product_id")]
        public int OrderReturnProductId { get; set; }
    }
}
