using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows you to edit the data of selected items (e.g. prices, quantities etc.) of a specific order return.
/// Only the fields that you want to edit should be given, the remaining fields can be omitted in the request.
/// </summary>
public class SetOrderReturnProductFields : IRequest
{
    /// <summary>
    /// Order return identifier from the BaseLinker order manager. Field required.
    /// </summary>
    [JsonPropertyName("return_id")]
    public int ReturnId { get; set; }

    /// <summary>
    /// Order return item ID from BaseLinker order manager. Field required.
    /// </summary>
    [JsonPropertyName("order_return_product_id")]
    public int OrderReturnProductId { get; set; }

    /// <summary>
    /// Type of product source storage (available values: "db" - BaseLinker internal inventory, "shop" - online shop storage, "warehouse" - the connected wholesaler)
    /// </summary>
    [JsonPropertyName("storage")]
    public string? Storage { get; set; }

    /// <summary>
    /// The identifier of the storage (inventory/shop/warehouse) from which the product comes.
    /// </summary>
    [JsonPropertyName("storage_id")]
    public string? StorageId { get; set; }

    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("variant_id")]
    public string? VariantId { get; set; }

    [JsonPropertyName("auction_id")]
    public string? AuctionId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    [JsonPropertyName("ean")]
    public string? Ean { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("warehouse_id")]
    public int? WarehouseId { get; set; }

    /// <summary>
    /// The detailed product attributes, e.g. "Colour: blue" (Variant name)
    /// </summary>
    [JsonPropertyName("attributes")]
    public string? Attributes { get; set; }

    /// <summary>
    /// Single item gross price.
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
    /// Identifier of product return status. The list can be retrieved with getOrderReturnProductStatuses method.
    /// </summary>
    [JsonPropertyName("status_id")]
    public int? StatusId { get; set; }

    /// <summary>
    /// Identifier of return reason. The list can be retrieved with getOrderReturnReasonsList method.
    /// </summary>
    [JsonPropertyName("return_reason_id")]
    public int? ReturnReasonId { get; set; }
}
