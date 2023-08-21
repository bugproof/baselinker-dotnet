using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// The method allows to download a series of invoice/receipt numbering.
/// </summary>
public class GetSeries : IRequest<GetSeries.Response>
{
    public class Series
    {
        /// <summary>
        /// Series numbering identifier
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Numbering type - possible values (INVOICE, RECEIPT)
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Numbering name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Numbering format
        /// </summary>
        [JsonPropertyName("format")]
        public string Format { get; set; }
    }
        
    public class Response : ResponseBase
    {
        [JsonPropertyName("series")]
        public List<Series> Series { get; set; }
    }
}