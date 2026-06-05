using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve a list of payers available in BaseLinker storage.
/// </summary>
public class GetInventoryPayers : IRequest<GetInventoryPayers.Response>
{
    /// <summary>
    /// (optional) Limiting results to a specific payer ID
    /// </summary>
    [JsonPropertyName("filter_id")]
    public int? FilterId { get; set; }

    /// <summary>
    /// (optional) Filtering by payer name (full or partial match)
    /// </summary>
    [JsonPropertyName("filter_name")]
    public string? FilterName { get; set; }

    public class Payer
    {
        /// <summary>
        /// Payer identifier
        /// </summary>
        [JsonPropertyName("payer_id")]
        public int PayerId { get; set; }

        /// <summary>
        /// Payer name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// (optional) Payer address
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// (optional) Payer postal code
        /// </summary>
        [JsonPropertyName("postcode")]
        public string Postcode { get; set; }

        /// <summary>
        /// (optional) Payer city
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// (optional) Payer tax identification number
        /// </summary>
        [JsonPropertyName("tax_no")]
        public string TaxNo { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("payers")]
        public List<Payer> Payers { get; set; }
    }
}
