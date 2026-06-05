using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// This method allows you to retrieve information about available inventory document series in BaseLinker.
/// Each series can be linked to a specific warehouse and can have its own numbering format settings.
/// </summary>
public class GetInventoryDocumentSeries : IRequest<GetInventoryDocumentSeries.Response>
{
    public class DocumentSeries
    {
        /// <summary>
        /// Unique identifier of the series
        /// </summary>
        [JsonPropertyName("document_series_id")]
        public int DocumentSeriesId { get; set; }

        /// <summary>
        /// The name of the series
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The type of document for which this series is intended: 0 - GR, 1 - IGR, 2 - GI, 3 - IGI, 4 - IT, 5 - OB
        /// </summary>
        [JsonPropertyName("document_type")]
        public int DocumentType { get; set; }

        /// <summary>
        /// The warehouse ID to which this series applies
        /// </summary>
        [JsonPropertyName("warehouse_id")]
        public int WarehouseId { get; set; }

        /// <summary>
        /// The format for document numbering
        /// </summary>
        [JsonPropertyName("format")]
        public string Format { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("document_series")]
        public List<DocumentSeries> DocumentSeries { get; set; }
    }
}
