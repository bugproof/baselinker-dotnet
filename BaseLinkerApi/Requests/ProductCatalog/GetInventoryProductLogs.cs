using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows to retrieve a list of events related to product change (or their variants) in the BaseLinker catalog.
/// </summary>
public class GetInventoryProductLogs : IRequest<GetInventoryProductLogs.Response>
{
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; }

    /// <summary>
    /// (optional) Date from which logs are to be retrieved. Unix time stamp format.
    /// </summary>
    [JsonPropertyName("date_from")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? DateFrom { get; set; }
        
    /// <summary>
    /// (optional) Date up to which logs are to be retrieved. Unix time stamp format.
    /// </summary>
    [JsonPropertyName("date_to")]
    [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
    public DateTimeOffset? DateTo { get; set; }

    /// <summary>
    /// (optional) List of event types you want to retrieve
    /// </summary>
    [JsonPropertyName("log_type")]
    public LogTypeEnum? LogType { get; set; }
        
    /// <summary>
    /// (optional) Type of log sorting. Possible "ASC" values ( ascending from date), "DESC" (descending after the date). By default the sorting is done in ascending order.
    /// </summary>
    [JsonPropertyName("sort")]
    public string? Sort { get; set; }
        
    /// <summary>
    /// (optional) Results paging (100 product editions per page).
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    public enum LogTypeEnum
    {
        ChangeInStock = 1,
        PriceChange,
        ProductCreation ,
        ProductDeletion,
        TextFieldsModifications,
        LocationsModifications,
        ModificationsOfLinks,
        GalleryModifications,
        VariantModifications,
        ModificationsOfBundleProducts
    }
        
    public class Entries
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        /// <summary>
        /// int or float
        /// </summary>
        [JsonPropertyName("from")]
        public object? From { get; set; }

        /// <summary>
        /// int or float
        /// </summary>
        [JsonPropertyName("to")]
        public object? To { get; set; }

        [JsonPropertyName("info")]
        public object Info { get; set; }
    }

    public class Log
    {
        [JsonPropertyName("profile")]
        public string Profile { get; set; }

        [JsonPropertyName("date")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("entries")]
        public Entries Entries { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("logs")]
        public List<Log> Logs { get; set; }
    }
}