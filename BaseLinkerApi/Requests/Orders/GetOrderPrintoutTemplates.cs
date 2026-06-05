using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// Returns a list of all configured printout templates available for orders.
/// The output includes technical identifiers used when executing a printout.
/// </summary>
public class GetOrderPrintoutTemplates : IRequest<GetOrderPrintoutTemplates.Response>
{
    public class Printout
    {
        /// <summary>
        /// Unique identifier of the printout template
        /// </summary>
        [JsonPropertyName("printout_id")]
        public int PrintoutId { get; set; }

        /// <summary>
        /// Name of the printout template
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Output format (e.g. PDF, HTML, XLS)
        /// </summary>
        [JsonPropertyName("file_format")]
        public string FileFormat { get; set; }

        /// <summary>
        /// Language of the template
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("printouts")]
        public List<Printout> Printouts { get; set; }
    }
}
