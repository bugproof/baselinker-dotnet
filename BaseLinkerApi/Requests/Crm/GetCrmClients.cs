using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Crm;

/// <summary>
/// The method allows you to retrieve a list of CRM clients. The client list can be limited using the filters described in the method parameters.
/// A maximum of 100 clients are returned at a time. To retrieve full client details (including notes and custom extra fields), use the getCrmClientData method.
/// </summary>
public class GetCrmClients : IRequest<GetCrmClients.Response>
{
    /// <summary>
    /// Results page number (100 results per page, numbered from 1).
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Filter by exact CRM client ID.
    /// </summary>
    [JsonPropertyName("filter_crm_client_id")]
    public int? FilterCrmClientId { get; set; }

    /// <summary>
    /// Filter by email (partial match).
    /// </summary>
    [JsonPropertyName("filter_email")]
    public string? FilterEmail { get; set; }

    /// <summary>
    /// Filter by phone (partial match).
    /// </summary>
    [JsonPropertyName("filter_phone")]
    public string? FilterPhone { get; set; }

    /// <summary>
    /// Filter by login (partial match).
    /// </summary>
    [JsonPropertyName("filter_login")]
    public string? FilterLogin { get; set; }

    /// <summary>
    /// Filter by invoice company name (partial match).
    /// </summary>
    [JsonPropertyName("filter_invoice_company")]
    public string? FilterInvoiceCompany { get; set; }

    /// <summary>
    /// Filter by invoice tax ID (partial match).
    /// </summary>
    [JsonPropertyName("filter_invoice_tax_id")]
    public string? FilterInvoiceTaxId { get; set; }

    /// <summary>
    /// Filter by invoice full name (partial match).
    /// </summary>
    [JsonPropertyName("filter_invoice_fullname")]
    public string? FilterInvoiceFullname { get; set; }

    /// <summary>
    /// Filter by exact status ID.
    /// </summary>
    [JsonPropertyName("filter_status_id")]
    public int? FilterStatusId { get; set; }

    public class Client
    {
        [JsonPropertyName("crm_client_id")]
        public int CrmClientId { get; set; }

        [JsonPropertyName("status_id")]
        public int StatusId { get; set; }

        /// <summary>
        /// Star type. Values from 0 to 5. 0 means no star.
        /// </summary>
        [JsonPropertyName("star")]
        public int Star { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Base Connect contractor ID associated with the client (0 if none).
        /// </summary>
        [JsonPropertyName("contractor_id")]
        public int ContractorId { get; set; }

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

        [JsonPropertyName("invoice_country_code")]
        public string InvoiceCountryCode { get; set; }

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

        [JsonPropertyName("delivery_country_code")]
        public string DeliveryCountryCode { get; set; }

        /// <summary>
        /// Additional not parsed data
        /// </summary>
        [JsonExtensionData] public Dictionary<string, JsonElement>? ExtensionsData { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("clients")]
        public List<Client> Clients { get; set; }
    }
}
