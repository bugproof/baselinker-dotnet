using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;

namespace BaseLinkerApi.Requests.ProductsStorage
{
    /// <summary>
    /// The method allows you to add a new product to BaseLinker storage. Entering the product with the ID updates previously saved product.
    /// </summary>
    [Obsolete]
    public class AddProduct : IRequest<AddProduct.Response>
    {
        public class Feature
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("value")]
            public string Value { get; set; }
        }
        
        [JsonPropertyName("storage_id")]
        public string StorageId { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("ean")]
        public string Ean { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("price_brutto")]
        public decimal PriceBrutto { get; set; }

        [JsonPropertyName("price_wholesale_netto")]
        public decimal PriceWholesaleNetto { get; set; }

        [JsonPropertyName("tax_rate")]
        public double TaxRate { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("description_extra1")]
        public string DescriptionExtra1 { get; set; }

        [JsonPropertyName("description_extra2")]
        public string DescriptionExtra2 { get; set; }

        [JsonPropertyName("man_name")]
        public string ManName { get; set; }

        [JsonPropertyName("category_id")]
        public string CategoryId { get; set; }

        [JsonPropertyName("images")]
        public List<string> Images { get; set; }

        [JsonPropertyName("features")]
        public List<Feature> Features { get; set; }
        
        public class Response : ResponseBase
        {
            [JsonPropertyName("storage_id")]
            public string StorageId { get; set; }

            [JsonPropertyName("product_id")]
            public string ProductId { get; set; }

            [JsonPropertyName("warnings")]
            public Dictionary<string, string> Warnings { get; set; }
        }
    }
}