using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows you to edit selected fields (e.g. address data, notes, etc.) of a specific order. Only the fields that you want to edit should be given, other fields can be omitted in the request.
/// </summary>
public class SetOrderFields : IRequest
{
    /// <summary>
    /// Order identifier from the BaseLinker order manager. Field required. Other fields are optional.
    /// </summary>
    [JsonPropertyName("order_id")]
    public int OrderId { get; set; }

    /// <summary>
    /// Seller comments
    /// </summary>
    [JsonPropertyName("admin_comments")]
    public string? AdminComments { get; set; }
        
    /// <summary>
    /// Buyer comments
    /// </summary>
    [JsonPropertyName("user_comments")]
    public string? UserComments { get; set; }
        
    /// <summary>
    /// Payment method
    /// </summary>
    [JsonPropertyName("payment_method")]
    public string? PaymentMethod { get; set; }
        
    /// <summary>
    /// Flag indicating whether the type of payment is COD (cash on delivery)
    /// </summary>
    [JsonPropertyName("payment_method_cod")]
    public bool? PaymentMethodCod { get; set; }

    /// <summary>
    /// Delivery method name
    /// </summary>
    [JsonPropertyName("delivery_method")]
    public string? DeliveryMethod { get; set; }
        
    /// <summary>
    /// Gross delivery price
    /// </summary>
    [JsonPropertyName("delivery_price")]
    public decimal? DeliveryPrice { get; set; }
        
    /// <summary>
    /// Delivery address - name and surname
    /// </summary>
    [JsonPropertyName("delivery_fullname")]
    public string? DeliveryFullname { get; set; }
        
    /// <summary>
    /// Delivery address - company
    /// </summary>
    [JsonPropertyName("delivery_company")]
    public string? DeliveryCompany { get; set; }
        
    /// <summary>
    /// Delivery address - street and number
    /// </summary>
    [JsonPropertyName("delivery_address")]
    public string? DeliveryAddress { get; set; }
        
    /// <summary>
    /// Delivery address - postcode
    /// </summary>
    [JsonPropertyName("delivery_postcode")]
    public string? DeliveryPostcode { get; set; }
        
    /// <summary>
    /// Delivery address - city
    /// </summary>
    [JsonPropertyName("delivery_city")]
    public string? DeliveryCity { get; set; }
    
    /// <summary>
    /// Delivery address - state/province
    /// </summary>
    [JsonPropertyName("delivery_state")]
    public string? DeliveryState { get; set; }
        
    /// <summary>
    /// Delivery address - country code (two-letter, e.g. EN)
    /// </summary>
    [JsonPropertyName("delivery_country_code")]
    public string? DeliveryCountryCode { get; set; }
        
    /// <summary>
    /// Pick-up point delivery - pick-up point identifier
    /// </summary>
    [JsonPropertyName("delivery_point_id")]
    public string? DeliveryPointId { get; set; }
        
    /// <summary>
    /// Pick-up point delivery - pick-up point name
    /// </summary>
    [JsonPropertyName("delivery_point_name")]
    public string? DeliveryPointName { get; set; }
        
    /// <summary>
    /// Pick-up point delivery - pick-up point address
    /// </summary>
    [JsonPropertyName("delivery_point_address")]
    public string? DeliveryPointAddress { get; set; }
        
    /// <summary>
    /// Pick-up point delivery - pick-up point postcode
    /// </summary>
    [JsonPropertyName("delivery_point_postcode")]
    public string? DeliveryPointPostcode { get; set; }
        
    /// <summary>
    /// Pick-up point delivery - pick-up point city
    /// </summary>
    [JsonPropertyName("delivery_point_city")]
    public string? DeliveryPointCity { get; set; }
        
    /// <summary>
    /// Billing details - name and surname
    /// </summary>
    [JsonPropertyName("invoice_fullname")]
    public string? InvoiceFullname { get; set; }
        
    /// <summary>
    /// Billing details - company
    /// </summary>
    [JsonPropertyName("invoice_company")]
    public string? InvoiceCompany { get; set; }
        
    /// <summary>
    /// Billing details - Vat Reg. no./tax number
    /// </summary>
    [JsonPropertyName("invoice_nip")]
    public string? InvoiceNip { get; set; }
        
    /// <summary>
    /// Billing details - street and house number
    /// </summary>
    [JsonPropertyName("invoice_address")]
    public string? InvoiceAddress { get; set; }
        
    /// <summary>
    /// Billing details - postcode
    /// </summary>
    [JsonPropertyName("invoice_postcode")]
    public string? InvoicePostcode { get; set; }
        
    /// <summary>
    /// Billing details - city
    /// </summary>
    [JsonPropertyName("invoice_city")]
    public string? InvoiceCity { get; set; }
    
    /// <summary>
    /// Billing details - state/province
    /// </summary>
    [JsonPropertyName("invoice_state")]
    public string? InvoiceState { get; set; }
        
    /// <summary>
    /// Billing details - country code (two-letter, e.g. EN)
    /// </summary>
    [JsonPropertyName("invoice_country_code")]
    public string? InvoiceCountryCode { get; set; }
        
    /// <summary>
    /// Flag indicating whether the customer wants an invoice
    /// </summary>
    [JsonPropertyName("want_invoice")]
    public bool? WantInvoice { get; set; }
        
    /// <summary>
    /// Value from "extra field 1". - the seller can store any information there
    /// </summary>
    [Obsolete]
    [JsonPropertyName("extra_field_1")]
    public string? ExtraField1 { get; set; }
        
    /// <summary>
    /// Value from "extra field 2". - the seller can store any information there
    /// </summary>
    [Obsolete]
    [JsonPropertyName("extra_field_2")]
    public string? ExtraField2 { get; set; }
        
    [JsonPropertyName("custom_extra_fields")]
    public Dictionary<object, object> CustomExtraFields { get; set; }
    
    /// <summary>
    /// Flag indicating the status of the order products collection (1 - all products have been collected, 0 - not all products have been collected)
    /// </summary>
    [JsonPropertyName("pick_state")]
    public int? PickState { get; set; }
        
    /// <summary>
    /// Flag indicating the status of the order products packing (1 - all products have been packed, 0 - not all products have been packed)
    /// </summary>
    [JsonPropertyName("pack_state")]
    public int? PackState { get; set; }
}