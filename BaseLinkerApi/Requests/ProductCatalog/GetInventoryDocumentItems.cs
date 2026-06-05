using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductCatalog;

/// <summary>
/// This method allows you to retrieve document items for a specific inventory document in BaseLinker.
/// In case of a large number of items, pagination is possible.
/// </summary>
public class GetInventoryDocumentItems : IRequest<GetInventoryDocumentItems.Response>
{
    /// <summary>
    /// Inventory document ID
    /// </summary>
    [JsonPropertyName("document_id")]
    public int DocumentId { get; set; }

    /// <summary>
    /// (optional) Results page number (100 items per page, numbered from 1)
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    public class Item
    {
        /// <summary>
        /// The ID of the document to which this item belongs
        /// </summary>
        [JsonPropertyName("document_id")]
        public int DocumentId { get; set; }

        /// <summary>
        /// The main identifier of the document item
        /// </summary>
        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }

        /// <summary>
        /// The line item number within the document
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; set; }

        /// <summary>
        /// The product ID
        /// </summary>
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// The product name as copied at the time of document creation
        /// </summary>
        [JsonPropertyName("product_name")]
        public string ProductName { get; set; }

        /// <summary>
        /// The product EAN
        /// </summary>
        [JsonPropertyName("product_ean")]
        public string ProductEan { get; set; }

        /// <summary>
        /// The product SKU
        /// </summary>
        [JsonPropertyName("product_sku")]
        public string ProductSku { get; set; }

        /// <summary>
        /// The quantity of this line item in the document
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// The total value of the item
        /// </summary>
        [JsonPropertyName("total_price")]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// The catalog ID
        /// </summary>
        [JsonPropertyName("inventory_id")]
        public int InventoryId { get; set; }

        /// <summary>
        /// The location
        /// </summary>
        [JsonPropertyName("location_name")]
        public string LocationName { get; set; }

        /// <summary>
        /// The expiry date. Date format YYYY-MM-DD (ISO 8601)
        /// </summary>
        [JsonPropertyName("expiry_date")]
        public string ExpiryDate { get; set; }

        /// <summary>
        /// The product batch
        /// </summary>
        [JsonPropertyName("batch")]
        public string Batch { get; set; }

        /// <summary>
        /// The product serial number
        /// </summary>
        [JsonPropertyName("serial_no")]
        public string SerialNo { get; set; }

        /// <summary>
        /// Item comments or notes
        /// </summary>
        [JsonPropertyName("comments")]
        public string Comments { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }
}
