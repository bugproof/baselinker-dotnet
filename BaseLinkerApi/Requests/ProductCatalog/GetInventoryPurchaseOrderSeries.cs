using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to retrieve a list of purchase order document series available in BaseLinker storage.
/// </summary>
public class GetInventoryPurchaseOrderSeries : IRequest<GetInventoryPurchaseOrderSeries.Response>
{
    /// <summary>
    /// (optional) Filter series by warehouse ID
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public int? WarehouseId { get; set; }

    public class Series
    {
        /// <summary>
        /// Series identifier
        /// </summary>
        [JsonPropertyName("series_id")]
        public int SeriesId { get; set; }

        /// <summary>
        /// Series name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Warehouse identifier
        /// </summary>
        [JsonPropertyName("warehouse_id")]
        public int WarehouseId { get; set; }

        /// <summary>
        /// Document number format
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
