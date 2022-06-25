using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common.JsonConverters;
using Xunit;
using Xunit.Abstractions;

namespace BaseLinkerApi.Tests
{
    public class DeserializationTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private static readonly JsonSerializerOptions JsonSerializerOptions = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, Converters = { new BoolConverter(), new StringToNullableDecimalConverter() }};

        public DeserializationTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Issue7()
        {
            var response = JsonSerializer.Deserialize<Requests.Orders.GetInvoices.Response>("{\"status\":\"SUCCESS\",\"invoices\":[{\"invoice_id\":1818929,\"order_id\":10905553,\"series_id\":44517,\"type\":\"normal\",\"number\":\"2\\/9\\/2021\",\"year\":2021,\"month\":9,\"sub_id\":2,\"postfix\":\"\",\"date_add\":1632140552,\"date_sell\":1632140552,\"date_pay_to\":0,\"currency\":\"PLN\",\"total_price_brutto\":499.95,\"total_price_netto\":416.625,\"invoice_fullname\":\"\",\"invoice_company\":\"\",\"invoice_nip\":\"\",\"invoice_address\":\"\",\"invoice_city\":\"\",\"invoice_postcode\":\"\",\"invoice_country\":\"\",\"invoice_country_code\":\"\",\"seller\":\"Rafal\\nTest 1\\n01-376, Test\\n\",\"payment\":\"Blik\",\"additional_info\":\"\",\"correcting_to_invoice_id\":0,\"correcting_reason\":\"\",\"correcting_items\":false,\"correcting_data\":false,\"external_invoice_number\":\"\",\"external_id\":\"1818929\",\"exchange_currency\":\"\",\"exchange_rate\":\"\",\"exchange_date\":\"\",\"exchange_info\":\"\",\"items\":[{\"name\":\"iPhone XBL\",\"sku\":\"\",\"ean\":\"\",\"price_brutto\":499.95,\"price_netto\":416.625,\"tax_rate\":20,\"quantity\":1}]}]}", JsonSerializerOptions);
            Assert.Null(response.Invoices[0].ExchangeRate);
            var response2 = JsonSerializer.Deserialize<Requests.Orders.GetInvoices.Response>("{\"status\":\"SUCCESS\",\"invoices\":[{\"invoice_id\":1850244,\"order_id\":10905554,\"series_id\":44517,\"type\":\"normal\",\"number\":\"3\\/9\\/2021\",\"year\":2021,\"month\":9,\"sub_id\":3,\"postfix\":\"\",\"date_add\":1632294116,\"date_sell\":1632294116,\"date_pay_to\":0,\"currency\":\"EUR\",\"total_price_brutto\":709.48,\"total_price_netto\":709.48,\"invoice_fullname\":\"\",\"invoice_company\":\"\",\"invoice_nip\":\"\",\"invoice_address\":\"\",\"invoice_city\":\"\",\"invoice_postcode\":\"\",\"invoice_country\":\"\",\"invoice_country_code\":\"\",\"seller\":\"Rafal\\nTest 1\\n01-376, Test\\n\",\"payment\":\"\",\"additional_info\":\"\",\"correcting_to_invoice_id\":0,\"correcting_reason\":\"\",\"correcting_items\":false,\"correcting_data\":false,\"external_invoice_number\":\"\",\"external_id\":\"\",\"exchange_currency\":\"PLN\",\"exchange_rate\":4.5789,\"exchange_date\":\"2021-09-17\",\"exchange_info\":\"181\\/A\\/NBP\\/2021\",\"items\":[{\"name\":\"Google Pixel 5\",\"sku\":\"\",\"ean\":\"\",\"price_brutto\":349.99,\"price_netto\":349.99,\"tax_rate\":0,\"quantity\":2},{\"name\":\"USB Charger\",\"sku\":\"\",\"ean\":\"\",\"price_brutto\":9.5,\"price_netto\":9.5,\"tax_rate\":0,\"quantity\":1}]}]}", JsonSerializerOptions);
            Assert.Equal(4.5789m, response2.Invoices[0].ExchangeRate);
        }
    }
}