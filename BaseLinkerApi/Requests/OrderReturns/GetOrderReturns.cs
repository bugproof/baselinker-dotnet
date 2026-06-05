using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows you to download order returns from a specific date from the BaseLinker return manager.
/// The return list can be limited using the filters described in the method parameters. A maximum of 100 order returns are returned at a time.
/// </summary>
public class GetOrderReturns : IRequest<GetOrderReturns.Response>
{
    /// <summary>
    /// (optional) Identifier of an order the return was created from.
    /// </summary>
    [JsonPropertyName("order_id")]
    public int? OrderId { get; set; }

    /// <summary>
    /// (optional) Order return identifier. Completing this field will download information about only one specific order return.
    /// </summary>
    [JsonPropertyName("return_id")]
    public int? ReturnId { get; set; }

    /// <summary>
    /// (optional) The return creation date from which order returns are to be collected. Format unix time stamp.
    /// </summary>
    [JsonPropertyName("date_from")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? DateFrom { get; set; }

    /// <summary>
    /// (optional) The order return ID number from which subsequent order returns are to be collected.
    /// </summary>
    [JsonPropertyName("id_from")]
    public int? IdFrom { get; set; }

    /// <summary>
    /// (optional) The status identifier from which order returns are to be collected. Leave blank to download order returns from all statuses.
    /// </summary>
    [JsonPropertyName("status_id")]
    public int? StatusId { get; set; }

    /// <summary>
    /// (optional) Filtering of order return lists by order return source, for instance "ebay", "amazon".
    /// The list of order return sources can be retrieved with getOrderSources method.
    /// </summary>
    [JsonPropertyName("filter_order_return_source")]
    public string? FilterOrderReturnSource { get; set; }

    /// <summary>
    /// (optional) Filtering of order return lists by order return source identifier.
    /// Filtering by order return source identifier requires "filter_order_return_source" to be set prior.
    /// </summary>
    [JsonPropertyName("filter_order_return_source_id")]
    public int? FilterOrderReturnSourceId { get; set; }

    /// <summary>
    /// (optional, false by default) Download values of custom additional fields.
    /// </summary>
    [JsonPropertyName("include_custom_extra_fields")]
    public bool? IncludeCustomExtraFields { get; set; }

    public class Product
    {
        [JsonPropertyName("order_product_id")]
        public int OrderProductId { get; set; }

        [JsonPropertyName("storage")]
        public string Storage { get; set; }

        [JsonPropertyName("storage_id")]
        public int StorageId { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("variant_id")]
        public int VariantId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("ean")]
        public string Ean { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("warehouse_id")]
        public int WarehouseId { get; set; }

        [JsonPropertyName("attributes")]
        public string Attributes { get; set; }

        [JsonPropertyName("price_brutto")]
        public double PriceBrutto { get; set; }

        [JsonPropertyName("tax_rate")]
        public double TaxRate { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("status_id")]
        public int StatusId { get; set; }

        [JsonPropertyName("return_reason_id")]
        public int ReturnReasonId { get; set; }

        /// <summary>
        /// Additional not parsed data
        /// </summary>
        [JsonExtensionData] public Dictionary<string, JsonElement>? ExtensionsData { get; set; }
    }

    public class Return
    {
        [JsonPropertyName("return_id")]
        public int ReturnId { get; set; }

        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        [JsonPropertyName("shop_order_id")]
        public int ShopOrderId { get; set; }

        [JsonPropertyName("external_order_id")]
        public string ExternalOrderId { get; set; }

        [JsonPropertyName("reference_number")]
        public string ReferenceNumber { get; set; }

        [JsonPropertyName("order_return_source")]
        public string OrderReturnSource { get; set; }

        [JsonPropertyName("order_return_source_id")]
        public int OrderReturnSourceId { get; set; }

        [JsonPropertyName("status_id")]
        public int StatusId { get; set; }

        [JsonPropertyName("date_add")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateAdd { get; set; }

        [JsonPropertyName("date_in_status")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateInStatus { get; set; }

        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Information whether the order return is already refunded.
        /// </summary>
        [JsonPropertyName("refunded")]
        public string Refunded { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("delivery_price")]
        public double DeliveryPrice { get; set; }

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

        [JsonPropertyName("delivery_country")]
        public string DeliveryCountry { get; set; }

        [JsonPropertyName("delivery_country_code")]
        public string DeliveryCountryCode { get; set; }

        [JsonPropertyName("extra_field_1")]
        public string ExtraField1 { get; set; }

        [JsonPropertyName("extra_field_2")]
        public string ExtraField2 { get; set; }

        [JsonPropertyName("custom_extra_fields")]
        public Dictionary<string, object> CustomExtraFields { get; set; }

        [JsonPropertyName("admin_comments")]
        public string AdminComments { get; set; }

        [JsonPropertyName("delivery_package_module")]
        public string DeliveryPackageModule { get; set; }

        [JsonPropertyName("delivery_package_nr")]
        public string DeliveryPackageNr { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }

        [JsonPropertyName("order_return_account_number")]
        public string OrderReturnAccountNumber { get; set; }

        [JsonPropertyName("order_return_iban")]
        public string OrderReturnIban { get; set; }

        [JsonPropertyName("order_return_swift")]
        public string OrderReturnSwift { get; set; }

        /// <summary>
        /// Fulfillment status ID: 0 - active, 5 - accepted, 1 - done, 2 - canceled
        /// </summary>
        [JsonPropertyName("fulfillment_status")]
        public int FulfillmentStatus { get; set; }

        /// <summary>
        /// Additional not parsed data
        /// </summary>
        [JsonExtensionData] public Dictionary<string, JsonElement>? ExtensionsData { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("returns")]
        public List<Return> Returns { get; set; }
    }
}
