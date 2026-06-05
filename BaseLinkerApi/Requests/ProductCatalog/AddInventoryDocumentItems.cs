using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// The method allows you to add items to an existing inventory document.
/// </summary>
public class AddInventoryDocumentItems : IRequest<AddInventoryDocumentItems.Response>
{
    /// <summary>
    /// Document identifier
    /// </summary>
    [JsonPropertyName("document_id")]
    public int DocumentId { get; set; }

    public class Item
    {
        /// <summary>
        /// The product ID
        /// </summary>
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// The quantity of this line item in the document
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// (optional) Item unit price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// (optional) Source storage location
        /// </summary>
        [JsonPropertyName("location_name")]
        public string? LocationName { get; set; }

        /// <summary>
        /// (optional) Target storage location (only for Internal Transfer documents)
        /// </summary>
        [JsonPropertyName("target_location_name")]
        public string? TargetLocationName { get; set; }

        /// <summary>
        /// (optional) The expiry date. Date format YYYY-MM-DD (ISO 8601)
        /// </summary>
        [JsonPropertyName("expiry_date")]
        public string? ExpiryDate { get; set; }

        /// <summary>
        /// (optional) Batch number
        /// </summary>
        [JsonPropertyName("batch")]
        public string? Batch { get; set; }

        /// <summary>
        /// (optional) The product serial number
        /// </summary>
        [JsonPropertyName("serial_no")]
        public string? SerialNo { get; set; }

        /// <summary>
        /// (optional) Item comments or notes
        /// </summary>
        [JsonPropertyName("comments")]
        public string? Comments { get; set; }
    }

    /// <summary>
    /// List of document items
    /// </summary>
    [JsonPropertyName("items")]
    public List<Item> Items { get; set; }

    public class Response : ResponseBase
    {
        public class CreatedItem
        {
            /// <summary>
            /// Created item identifier
            /// </summary>
            [JsonPropertyName("item_id")]
            public int ItemId { get; set; }
        }

        [JsonPropertyName("items")]
        public List<CreatedItem> Items { get; set; }
    }
}
