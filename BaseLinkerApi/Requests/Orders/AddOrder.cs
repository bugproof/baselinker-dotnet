using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows adding a new order to the BaseLinker order manager.
/// </summary>
public class AddOrder : IRequest<AddOrder.Response>
{
    public class Product
    {
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
        public decimal PriceBrutto { get; set; }

        [JsonPropertyName("tax_rate")]
        public double TaxRate { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }
    }
        
    /// <summary>
    /// Order status (the list available to retrieve with getOrderStatusList)
    /// </summary>
    [JsonPropertyName("order_status_id")]
    public string OrderStatusId { get; set; }
        
    /// <summary>
    /// (optional) Identifier of custom order source defined in BaseLinker panel. If not provided, default order source is assigned.
    /// </summary>
    [JsonPropertyName("custom_source_id")]
    public int? CustomSourceId { get; set; }

    /// <summary>
    /// Date of order creation (in unix time format)
    /// </summary>
    [JsonPropertyName("date_add")]
    public string DateAdd { get; set; }

    [JsonPropertyName("user_comments")]
    public string UserComments { get; set; }

    [JsonPropertyName("admin_comments")]
    public string AdminComments { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("user_login")]
    public string UserLogin { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("payment_method")]
    public string PaymentMethod { get; set; }

    [JsonPropertyName("payment_method_cod")]
    public string PaymentMethodCod { get; set; }

    [JsonPropertyName("paid")]
    public string Paid { get; set; }

    [JsonPropertyName("delivery_method")]
    public string DeliveryMethod { get; set; }

    [JsonPropertyName("delivery_price")]
    public string DeliveryPrice { get; set; }

    [JsonPropertyName("delivery_fullname")]
    public string DeliveryFullname { get; set; }

    [JsonPropertyName("delivery_company")]
    public string DeliveryCompany { get; set; }

    [JsonPropertyName("delivery_address")]
    public string DeliveryAddress { get; set; }

    [JsonPropertyName("delivery_city")]
    public string DeliveryCity { get; set; }

    [JsonPropertyName("delivery_postcode")]
    public string DeliveryPostcode { get; set; }
    
    [JsonPropertyName("delivery_state")]
    public string DeliveryState { get; set; }

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

    [JsonPropertyName("invoice_postcode")]
    public string InvoicePostcode { get; set; }
    
    [JsonPropertyName("invoice_state")]
    public string InvoiceState { get; set; }

    [JsonPropertyName("invoice_country_code")]
    public string InvoiceCountryCode { get; set; }

    [JsonPropertyName("want_invoice")]
    public string WantInvoice { get; set; }

    [Obsolete]
    [JsonPropertyName("extra_field_1")]
    public string ExtraField1 { get; set; }

    [Obsolete]
    [JsonPropertyName("extra_field_2")]
    public string ExtraField2 { get; set; }

    [JsonPropertyName("custom_extra_fields")]
    public Dictionary<object, object> CustomExtraFields { get; set; }
    
    [JsonPropertyName("products")]
    public List<Product> Products { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// ID of added order.
        /// </summary>
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }
    }
}