using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve a list of suppliers available in BaseLinker storage.
/// </summary>
public class GetInventorySuppliers : IRequest<GetInventorySuppliers.Response>
{
    /// <summary>
    /// (optional) Limiting results to a specific supplier ID
    /// </summary>
    [JsonPropertyName("filter_id")]
    public int? FilterId { get; set; }

    /// <summary>
    /// (optional) Filtering by supplier name (full or partial match)
    /// </summary>
    [JsonPropertyName("filter_name")]
    public string? FilterName { get; set; }

    public class Supplier
    {
        /// <summary>
        /// Supplier identifier
        /// </summary>
        [JsonPropertyName("supplier_id")]
        public int SupplierId { get; set; }

        /// <summary>
        /// Supplier name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// (optional) Supplier address
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// (optional) Supplier postal code
        /// </summary>
        [JsonPropertyName("postcode")]
        public string Postcode { get; set; }

        /// <summary>
        /// (optional) Supplier city
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// (optional) Supplier phone number
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// (optional) Supplier email address
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// (optional) Additional email addresses for correspondence
        /// </summary>
        [JsonPropertyName("email_copy_to")]
        public string EmailCopyTo { get; set; }

        /// <summary>
        /// (optional) Default supplier currency (e.g. EUR, USD)
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("suppliers")]
        public List<Supplier> Suppliers { get; set; }
    }
}
