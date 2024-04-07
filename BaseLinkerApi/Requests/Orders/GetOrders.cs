using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.Orders;

public class GetOrders : IRequest<GetOrders.Response>
{
    /// <summary>
    /// (optional) Order identifier. Completing this field will download information about only one specific order.
    /// </summary>
    [JsonPropertyName("order_id")]
    public int? OrderId { get; set; }
        
    /// <summary>
    /// (optional) Date of order confirmation from which orders are to be collected. Format unix time stamp.
    /// </summary>
    [JsonPropertyName("date_confirmed_from")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? DateConfirmedFrom { get; set; }
        
    /// <summary>
    /// (optional) The order date from which orders are to be collected. Format unix time stamp.
    /// </summary>
    [JsonPropertyName("date_from")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? DateFrom { get; set; }
        
    /// <summary>
    /// (optional) The order ID number from which subsequent orders are to be collected.
    /// </summary>
    [JsonPropertyName("id_from")]
    public int? IdFrom { get; set; }
        
    /// <summary>
    /// (optional, false by default) Download unconfirmed orders as well (this is e.g. an order from Allegro to which the customer has not yet completed the delivery form). Default is false.
    /// Unconfirmed orders may not be complete yet, the shipping method and price is also unknown.
    /// </summary>
    [JsonPropertyName("get_unconfirmed_orders")]
    public bool? GetUnconfirmedOrders { get; set; }

    /// <summary>
    /// (optional, false by default) Download values of custom additional fields.
    /// </summary>
    [JsonPropertyName("include_custom_extra_fields")]
    public bool? IncludeCustomExtraFields { get; set; }
    
    /// <summary>
    /// (optional) The status identifier from which orders are to be collected. Leave blank to download orders from all statuses.
    /// </summary>
    [JsonPropertyName("status_id")]
    public int? StatusId { get; set; }
    
    /// <summary>
    /// (optional) Filtering of order lists by e-mail address (displays only orders with the given e-mail address).
    /// </summary>
    [JsonPropertyName("filter_email")]
    public string? FilterEmail { get; set; }
    
    /// <summary>
    /// (optional) Filtering of order lists by order source, for instance "ebay", "amazon" (displays only orders come from given source).
    /// The list of order sources can be retrieved with getOrderSources method.
    /// </summary>
    [JsonPropertyName("filter_order_source")]
    public string? FilterOrderSource { get; set; }
    
    /// <summary>
    /// (optional) Filtering of order lists by order source identifier, for instance "2523" (displays only orders come from order source defined in "filter_order_source" identified by given order source identifier).
    /// Filtering by order source indentifier requires "filter_order_source" to be set prior.
    /// The list of order source identifiers can be retrieved with getOrderSources method.
    /// </summary>
    [JsonPropertyName("filter_order_source_id")]
    public int? FilterOrderSourceId { get; set; }
    
    public class Product
    {
        [JsonPropertyName("storage")]
        public string Storage { get; set; }

        [JsonPropertyName("storage_id")]
        public int StorageId { get; set; }

        [JsonPropertyName("order_product_id")]
        public int OrderProductId { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("variant_id")]
        public string VariantId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("attributes")]
        public string Attributes { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("ean")]
        public string Ean { get; set; }
            
        [JsonPropertyName("location")]
        public string Location { get; set; }
            
        [JsonPropertyName("warehouse_id")]
        public int WarehouseId { get; set; }

        [JsonPropertyName("auction_id")]
        public string AuctionId { get; set; }

        [JsonPropertyName("price_brutto")]
        public double PriceBrutto { get; set; }

        [JsonPropertyName("tax_rate")]
        public double TaxRate { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }
        
        /// <summary>
        /// ID of the bundle that was split to acquire this order item. Only applies to bundles from BaseLinker inventory. Returns 0 if the product was not acquired from splitting a bundle.
        /// </summary>
        [JsonPropertyName("bundle_id")]
        public int BundleId { get; set; }
        
        /// <summary>
        /// Additional not parsed data
        /// </summary>
        [JsonExtensionData] public Dictionary<string, JsonElement>? ExtensionsData { get; set; }
    }

    public class Order
    {
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        [JsonPropertyName("shop_order_id")]
        public int ShopOrderId { get; set; }

        [JsonPropertyName("external_order_id")]
        public string ExternalOrderId { get; set; }

        [JsonPropertyName("order_source")]
        public string OrderSource { get; set; }

        [JsonPropertyName("order_source_id")]
        public int OrderSourceId { get; set; }

        [JsonPropertyName("order_source_info")]
        public string OrderSourceInfo { get; set; }

        [JsonPropertyName("order_status_id")]
        public int OrderStatusId { get; set; }

        [JsonPropertyName("date_add")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateAdd { get; set; }

        [JsonPropertyName("date_confirmed")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateConfirmed { get; set; }

        [JsonPropertyName("date_in_status")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateInStatus { get; set; }

        [JsonPropertyName("confirmed")]
        public bool Confirmed { get; set; }
            
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("user_comments")]
        public string UserComments { get; set; }

        [JsonPropertyName("admin_comments")]
        public string AdminComments { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("payment_method_cod")]
        public bool PaymentMethodCod { get; set; }

        [JsonPropertyName("payment_done")]
        public decimal PaymentDone { get; set; }

        [JsonPropertyName("delivery_method")]
        public string DeliveryMethod { get; set; }

        [JsonPropertyName("delivery_price")]
        public decimal DeliveryPrice { get; set; }

        [JsonPropertyName("delivery_package_module")]
        public string DeliveryPackageModule { get; set; }

        [JsonPropertyName("delivery_package_nr")]
        public string DeliveryPackageNr { get; set; }

        [JsonPropertyName("delivery_fullname")]
        public string DeliveryFullname { get; set; }

        [JsonPropertyName("delivery_company")]
        public string DeliveryCompany { get; set; }

        [JsonPropertyName("delivery_address")]
        public string DeliveryAddress { get; set; }

        [JsonPropertyName("delivery_city")]
        public string DeliveryCity { get; set; }
        
        [JsonPropertyName("delivery_state")]
        public string DeliveryState { get; set; }

        [JsonPropertyName("delivery_postcode")]
        public string DeliveryPostcode { get; set; }

        [JsonPropertyName("delivery_country")]
        public string DeliveryCountry { get; set; }

        [JsonPropertyName("delivery_country_code")]
        public string DeliveryCountryCode { get; set; }

        [JsonPropertyName("delivery_point_id")]
        public string DeliveryPointId { get; set; }

        [JsonPropertyName("delivery_point_name")]
        public string DeliveryPointName { get; set; }

        [JsonPropertyName("delivery_point_address")]
        public string DeliveryPointAddress { get; set; }

        [JsonPropertyName("delivery_point_postcode")]
        public string DeliveryPointPostcode { get; set; }

        [JsonPropertyName("delivery_point_city")]
        public string DeliveryPointCity { get; set; }

        [JsonPropertyName("invoice_fullname")]
        public string InvoiceFullname { get; set; }

        [JsonPropertyName("invoice_company")]
        public string InvoiceCompany { get; set; }

        [JsonPropertyName("invoice_nip")]
        public string InvoiceNip { get; set; }

        [JsonPropertyName("invoice_address")]
        public string InvoiceAddress { get; set; }

        [JsonPropertyName("invoice_city")]
        public string InvoiceCity { get; set; }
        
        [JsonPropertyName("invoice_state")]
        public string InvoiceState { get; set; }

        [JsonPropertyName("invoice_postcode")]
        public string InvoicePostcode { get; set; }

        [JsonPropertyName("invoice_country")]
        public string InvoiceCountry { get; set; }

        [JsonPropertyName("invoice_country_code")]
        public string InvoiceCountryCode { get; set; }

        [JsonPropertyName("want_invoice")]
        public bool WantInvoice { get; set; }

        [Obsolete]
        [JsonPropertyName("extra_field_1")]
        public string ExtraField1 { get; set; }

        [Obsolete]
        [JsonPropertyName("extra_field_2")]
        public string ExtraField2 { get; set; }
        
        [JsonPropertyName("custom_extra_fields")]
        public Dictionary<string, object> CustomExtraFields { get; set; }

        [JsonPropertyName("order_page")]
        public string OrderPage { get; set; }

        [JsonPropertyName("pick_status")]
        public int PickStatus { get; set; }

        [JsonPropertyName("pack_status")]
        public int PackStatus { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
        
        /// <summary>
        /// Additional not parsed data
        /// </summary>
        [JsonExtensionData] public Dictionary<string, JsonElement>? ExtensionsData { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("orders")]
        public List<Order> Orders { get; set; }
    }
}
