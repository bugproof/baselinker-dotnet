using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Crm;

/// <summary>
/// The method allows you to add a new CRM client. Adding a client with the same crm_client_id again will update
/// the previously saved client (only the provided fields will be changed).
/// </summary>
public class AddCrmClient : IRequest<AddCrmClient.Response>
{
    /// <summary>
    /// CRM client ID. If provided and greater than 0, the existing client will be updated. If 0 or omitted, a new client will be created.
    /// </summary>
    [JsonPropertyName("crm_client_id")]
    public int? CrmClientId { get; set; }

    /// <summary>
    /// CRM client status ID.
    /// </summary>
    [JsonPropertyName("status_id")]
    public int? StatusId { get; set; }

    /// <summary>
    /// Star type. Values from 0 to 5. 0 means no star.
    /// </summary>
    [JsonPropertyName("star")]
    public int? Star { get; set; }

    /// <summary>
    /// Base Connect contractor ID associated with the client (the list can be retrieved with getConnectIntegrationContractors method).
    /// </summary>
    [JsonPropertyName("contractor_id")]
    public int? ContractorId { get; set; }

    /// <summary>
    /// Client login name.
    /// </summary>
    [JsonPropertyName("login")]
    public string Login { get; set; }

    /// <summary>
    /// Client phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    /// <summary>
    /// Client email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// Client notes.
    /// </summary>
    [JsonPropertyName("notes")]
    public string Notes { get; set; }

    [JsonPropertyName("invoice_company")]
    public string InvoiceCompany { get; set; }

    [JsonPropertyName("invoice_fullname")]
    public string InvoiceFullname { get; set; }

    [JsonPropertyName("invoice_address")]
    public string InvoiceAddress { get; set; }

    [JsonPropertyName("invoice_postcode")]
    public string InvoicePostcode { get; set; }

    [JsonPropertyName("invoice_city")]
    public string InvoiceCity { get; set; }

    [JsonPropertyName("invoice_state")]
    public string InvoiceState { get; set; }

    /// <summary>
    /// Invoice country code (ISO 3166-1 alpha-2).
    /// </summary>
    [JsonPropertyName("invoice_country_code")]
    public string InvoiceCountryCode { get; set; }

    /// <summary>
    /// Invoice tax ID (NIP). Whitespace and dashes are automatically removed.
    /// </summary>
    [JsonPropertyName("invoice_tax_id")]
    public string InvoiceTaxId { get; set; }

    [JsonPropertyName("delivery_company")]
    public string DeliveryCompany { get; set; }

    [JsonPropertyName("delivery_fullname")]
    public string DeliveryFullname { get; set; }

    [JsonPropertyName("delivery_address")]
    public string DeliveryAddress { get; set; }

    [JsonPropertyName("delivery_postcode")]
    public string DeliveryPostcode { get; set; }

    [JsonPropertyName("delivery_city")]
    public string DeliveryCity { get; set; }

    [JsonPropertyName("delivery_state")]
    public string DeliveryState { get; set; }

    /// <summary>
    /// Delivery country code (ISO 3166-1 alpha-2).
    /// </summary>
    [JsonPropertyName("delivery_country_code")]
    public string DeliveryCountryCode { get; set; }

    /// <summary>
    /// A list containing CRM client custom extra fields, where the key is the extra field ID and value is an extra field content for given extra field.
    /// </summary>
    [JsonPropertyName("custom_extra_fields")]
    public Dictionary<string, object> CustomExtraFields { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// ID of the created or updated CRM client.
        /// </summary>
        [JsonPropertyName("crm_client_id")]
        public int CrmClientId { get; set; }
    }
}
