using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// Returns a list of all configured printout templates available for inventory (products).
/// </summary>
public class GetInventoryPrintoutTemplates : IRequest<GetInventoryPrintoutTemplates.Response>
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
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("printouts")]
        public List<Printout> Printouts { get; set; }
    }
}
