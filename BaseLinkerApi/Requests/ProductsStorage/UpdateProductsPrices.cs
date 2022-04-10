using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductsStorage;

/// <summary>
/// The method allows for bulk update of product prices (and/or variants) in BaseLinker storage. Maximum 1000 products at a time.
/// </summary>
[Obsolete]
public class UpdateProductsPrices : IRequest<UpdateProductsPrices.Response>
{
    public class Product
    {
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [JsonPropertyName("variant_id")]
        public int VariantId { get; set; }

        [JsonPropertyName("price_brutto")]
        public decimal PriceBrutto { get; set; }

        [JsonPropertyName("price_wholesale")]
        public decimal PriceWholesale { get; set; }

        [JsonPropertyName("tax_rate")]
        public double TaxRate { get; set; }
    }
        
    [JsonPropertyName("storage_id")]
    public string StorageId { get; set; }
        
    [JsonPropertyName("products")]
    public List<Product> Products { get; set; }
        
    public class Response : ResponseBase
    {
        /// <summary>
        /// Number of received items.
        /// </summary>
        [JsonPropertyName("counter")]
        public int Counter { get; set; }

        /// <summary>
        /// An array of warning notices for product updates. The key to each item is the identifier of the sent category, the value is an error message when adding. Only the keys containing errors are returned.
        /// </summary>
        [JsonPropertyName("warnings")]
        public Dictionary<string, string> Warnings { get; set; }
    }
}