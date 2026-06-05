using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows you to edit selected fields of a specific order return.
/// Only the fields that you want to edit should be given, other fields can be omitted in the request.
/// </summary>
public class SetOrderReturnFields : IRequest
{
    /// <summary>
    /// Order return identifier. Field required. Other fields are optional.
    /// </summary>
    [JsonPropertyName("return_id")]
    public int ReturnId { get; set; }

    /// <summary>
    /// Seller comments
    /// </summary>
    [JsonPropertyName("admin_comments")]
    public string? AdminComments { get; set; }

    /// <summary>
    /// Buyer e-mail address
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Buyer phone number
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Buyer login
    /// </summary>
    [JsonPropertyName("user_login")]
    public string? UserLogin { get; set; }

    /// <summary>
    /// Gross delivery price
    /// </summary>
    [JsonPropertyName("delivery_price")]
    public double? DeliveryPrice { get; set; }

    [JsonPropertyName("delivery_fullname")]
    public string? DeliveryFullname { get; set; }

    [JsonPropertyName("delivery_company")]
    public string? DeliveryCompany { get; set; }

    [JsonPropertyName("delivery_address")]
    public string? DeliveryAddress { get; set; }

    [JsonPropertyName("delivery_postcode")]
    public string? DeliveryPostcode { get; set; }

    [JsonPropertyName("delivery_city")]
    public string? DeliveryCity { get; set; }

    [JsonPropertyName("delivery_state")]
    public string? DeliveryState { get; set; }

    [JsonPropertyName("delivery_country_code")]
    public string? DeliveryCountryCode { get; set; }

    /// <summary>
    /// Value of the "extra field 1".
    /// </summary>
    [JsonPropertyName("extra_field_1")]
    public string? ExtraField1 { get; set; }

    /// <summary>
    /// Value of the "extra field 2".
    /// </summary>
    [JsonPropertyName("extra_field_2")]
    public string? ExtraField2 { get; set; }

    /// <summary>
    /// A list containing order return custom extra fields, where the key is the extra field ID and value is an extra field content for given extra field.
    /// The list of extra fields can be retrieved with getOrderReturnExtraFields method.
    /// </summary>
    [JsonPropertyName("custom_extra_fields")]
    public Dictionary<string, object>? CustomExtraFields { get; set; }
}
