using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.Orders;

/// <summary>
/// Merges multiple orders into one, based on the selected merge mode.
/// </summary>
public class SetOrdersMerge : IRequest<SetOrdersMerge.Response>
{
    /// <summary>
    /// ID of the main order (its shipping and invoice data will be retained).
    /// </summary>
    [JsonPropertyName("main_order_id")]
    public int MainOrderId { get; set; }

    /// <summary>
    /// List of other order IDs to merge. Must not include main_order_id.
    /// </summary>
    [JsonPropertyName("order_ids_to_merge")]
    public List<int> OrderIdsToMerge { get; set; }

    /// <summary>
    /// Merge mode: "technical_merge" (creates a new technical order without changing the originals)
    /// or "into_main_order" (moves items into the main order and deletes the others).
    /// </summary>
    [JsonPropertyName("merge_mode")]
    public string MergeMode { get; set; }

    /// <summary>
    /// Whether to sum delivery costs: true (add up all shipping costs from merged orders)
    /// or false (keep only the main order's shipping cost).
    /// </summary>
    [JsonPropertyName("sum_delivery_costs")]
    public bool SumDeliveryCosts { get; set; }

    public class Response : ResponseBase
    {
        /// <summary>
        /// ID of the merged order
        /// </summary>
        [JsonPropertyName("merged_order_id")]
        public int MergedOrderId { get; set; }
    }
}
