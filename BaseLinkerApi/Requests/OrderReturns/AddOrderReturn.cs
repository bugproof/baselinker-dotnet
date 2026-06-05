using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows adding a new order return to BaseLinker.
/// </summary>
public class AddOrderReturn : IRequest<AddOrderReturn.Response>
{
    public class Product
    {
        /// <summary>
        /// (optional) ID of connected order item from BaseLinker order manager.
        /// </summary>
        [JsonPropertyName("order_product_id")]
        public int? OrderProductId { get; set; }

        /// <summary>
        /// Type of warehouse from which the product comes (available values: "db" - BaseLinker internal inventory, "shop" - the online store warehouse, "warehouse" - a connected wholesaler).
        /// </summary>
        [JsonPropertyName("storage")]
        public string Storage { get; set; }

        /// <summary>
        /// The identifier of the warehouse from which the product comes. Value "0" for a product from the BaseLinker internal inventory.
        /// </summary>
        [JsonPropertyName("storage_id")]
        public int StorageId { get; set; }

        /// <summary>
        /// Product identifier in BaseLinker or store warehouse. Blank if the product number is unknown.
        /// </summary>
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// Product variant ID. Blank if the variant number is unknown.
        /// </summary>
        [JsonPropertyName("variant_id")]
        public int VariantId { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Product sku
        /// </summary>
        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Product ean
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
        public int WarehouseId { get; set; }

        /// <summary>
        /// Specific product attributes (e.g. "Color: blue")
        /// </summary>
        [JsonPropertyName("attributes")]
        public string Attributes { get; set; }

        /// <summary>
        /// Single item gross price
        /// </summary>
        [JsonPropertyName("price_brutto")]
        public double PriceBrutto { get; set; }

        /// <summary>
        /// VAT tax rate e.g. "23"
        /// </summary>
        [JsonPropertyName("tax_rate")]
        public double TaxRate { get; set; }

        /// <summary>
        /// Quantity of pieces
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Single item weight
        /// </summary>
        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        /// <summary>
        /// Identifier of return item status.
        /// </summary>
        [JsonPropertyName("status_id")]
        public int StatusId { get; set; }

        /// <summary>
        /// Identifier of return reason.
        /// </summary>
        [JsonPropertyName("return_reason_id")]
        public int ReturnReasonId { get; set; }
    }

    /// <summary>
    /// (optional) Order ID in BaseLinker panel
    /// </summary>
    [JsonPropertyName("order_id")]
    public int? OrderId { get; set; }

    /// <summary>
    /// Order return status (the list available to retrieve with getOrderReturnStatusList).
    /// </summary>
    [JsonPropertyName("status_id")]
    public int StatusId { get; set; }

    /// <summary>
    /// (optional) Identifier of custom order source defined in BaseLinker panel. If not provided, default order return source is assigned.
    /// </summary>
    [JsonPropertyName("custom_source_id")]
    public int? CustomSourceId { get; set; }

    /// <summary>
    /// (optional) Reference number from external source.
    /// </summary>
    [JsonPropertyName("reference_number")]
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Date of order return creation (in unix time format)
    /// </summary>
    [JsonPropertyName("date_add")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset DateAdd { get; set; }

    /// <summary>
    /// 3-letter currency symbol (e.g. EUR, PLN)
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Information whether the order return is already refunded. The value "1" automatically marks order return as refunded.
    /// </summary>
    [JsonPropertyName("refunded")]
    public bool? Refunded { get; set; }

    /// <summary>
    /// Seller comments
    /// </summary>
    [JsonPropertyName("admin_comments")]
    public string AdminComments { get; set; }

    /// <summary>
    /// Buyer e-mail address
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// Buyer phone number
    /// </summary>
    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    /// <summary>
    /// Marketplace user login
    /// </summary>
    [JsonPropertyName("user_login")]
    public string UserLogin { get; set; }

    /// <summary>
    /// Gross delivery price
    /// </summary>
    [JsonPropertyName("delivery_price")]
    public double? DeliveryPrice { get; set; }

    [JsonPropertyName("delivery_fullname")]
    public string DeliveryFullname { get; set; }

    [JsonPropertyName("delivery_company")]
    public string DeliveryCompany { get; set; }

    [JsonPropertyName("delivery_address")]
    public string DeliveryAddress { get; set; }

    [JsonPropertyName("delivery_postcode")]
    public string DeliveryPostcode { get; set; }

    [JsonPropertyName("delivery_city")]
    public string DeliveryCity { get; set; }

    [JsonPropertyName("delivery_state")]
    public string DeliveryState { get; set; }

    [JsonPropertyName("delivery_country_code")]
    public string DeliveryCountryCode { get; set; }

    /// <summary>
    /// Value of the "additional field 1"
    /// </summary>
    [JsonPropertyName("extra_field_1")]
    public string ExtraField1 { get; set; }

    /// <summary>
    /// Value of the "additional field 2"
    /// </summary>
    [JsonPropertyName("extra_field_2")]
    public string ExtraField2 { get; set; }

    /// <summary>
    /// A list containing order return custom extra fields, where the key is the extra field ID and value is an extra field content for given extra field.
    /// The list of extra fields can be retrieved with getOrderReturnExtraFields method.
    /// </summary>
    [JsonPropertyName("custom_extra_fields")]
    public Dictionary<string, object> CustomExtraFields { get; set; }

    /// <summary>
    /// Return product array.
    /// </summary>
    [JsonPropertyName("products")]
    public List<Product> Products { get; set; }

    /// <summary>
    /// Bank account number to issue a refund
    /// </summary>
    [JsonPropertyName("refund_account_number")]
    public string RefundAccountNumber { get; set; }

    /// <summary>
    /// IBAN of the bank account
    /// </summary>
    [JsonPropertyName("refund_iban")]
    public string RefundIban { get; set; }

    /// <summary>
    /// SWIFT of the bank account
    /// </summary>
    [JsonPropertyName("refund_swift")]
    public string RefundSwift { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// Identifier of added return.
        /// </summary>
        [JsonPropertyName("return_id")]
        public int ReturnId { get; set; }
    }
}
