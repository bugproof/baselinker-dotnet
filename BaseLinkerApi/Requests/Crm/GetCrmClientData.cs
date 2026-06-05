using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Crm;

/// <summary>
/// The method allows you to retrieve detailed data of a specific CRM client, including notes.
/// </summary>
public class GetCrmClientData : IRequest<GetCrmClientData.Response>
{
    /// <summary>
    /// ID of the CRM client to retrieve.
    /// </summary>
    [JsonPropertyName("crm_client_id")]
    public int CrmClientId { get; set; }

    /// <summary>
    /// (optional, false by default) Download values of custom additional fields.
    /// </summary>
    [JsonPropertyName("include_custom_extra_fields")]
    public bool? IncludeCustomExtraFields { get; set; }

    public class Response : ResponseBase
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

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

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
        /// A list containing CRM client custom extra fields returned only if the input parameter include_custom_extra_fields is set to true.
        /// </summary>
        [JsonPropertyName("custom_extra_fields")]
        public Dictionary<string, object> CustomExtraFields { get; set; }
    }
}
