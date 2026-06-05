using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to add a new payer or update an existing one in BaseLinker storage.
/// </summary>
public class AddInventoryPayer : IRequest<AddInventoryPayer.Response>
{
    /// <summary>
    /// (optional) Payer identifier. If provided, the existing payer will be updated.
    /// </summary>
    [JsonPropertyName("payer_id")]
    public int? PayerId { get; set; }

    /// <summary>
    /// Payer name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// (optional) Payer address
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// (optional) Payer postal code
    /// </summary>
    [JsonPropertyName("postcode")]
    public string? Postcode { get; set; }

    /// <summary>
    /// (optional) Payer city
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// (optional) Payer tax identification number
    /// </summary>
    [JsonPropertyName("tax_no")]
    public string? TaxNo { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// Created or updated payer identifier
        /// </summary>
        [JsonPropertyName("payer_id")]
        public int PayerId { get; set; }
    }
}
