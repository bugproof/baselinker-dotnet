using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to add a new product to your order.
/// </summary>
public class AddOrderProduct : IRequest<AddOrderProduct.Response>
{
    /// <summary>
    /// Order Identifier from BaseLinker order manager
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// Type of product source storage (available values: "db" - BaseLinker internal catalog, "shop" - online shop storage, "warehouse" - the connected wholesaler)
    /// </summary>
    [JsonPropertyName("storage")]
    public string Storage { get; set; }

    /// <summary>
    /// ID of the product source storage (one from BaseLinker catalogs or one of the stores connected to the account). Value "0" when the product comes from BaseLinker internal catalog.
    /// </summary>
    [JsonPropertyName("storage_id")]
    public int StorageId { get; set; }

    /// <summary>
    /// Product identifier in BaseLinker or shop storage. Blank if the product number is not known
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; }

    /// <summary>
    /// Product variant ID. Blank if the variant number is unknown
    /// </summary>
    [JsonPropertyName("variant_id")]
    public string VariantId { get; set; }

    /// <summary>
    ///	Listing ID number (if the order comes from ebay/allegro)
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
        
    [JsonPropertyName("warehouse_id")]
    public int WarehouseId { get; set; }

    /// <summary>
    /// The detailed product attributes, e.g. "Colour: blue" (Variant name)
    /// </summary>
    [JsonPropertyName("attributes")]
    public string Attributes { get; set; }

    /// <summary>
    /// Single item gross price
    /// </summary>
    [JsonPropertyName("price_brutto")]
    public decimal PriceBrutto { get; set; }

    /// <summary>
    /// VAT rate
    /// </summary>
    [JsonPropertyName("tax_rate")]
    public double TaxRate { get; set; }

    /// <summary>
    /// Number of pieces
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// Single piece weight
    /// </summary>
    [JsonPropertyName("weight")]
    public double Weight { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// Identifier of the item added to the order.
        /// </summary>
        [JsonPropertyName("order_product_id")]
        public string OrderProductId { get; set; }
    }
}