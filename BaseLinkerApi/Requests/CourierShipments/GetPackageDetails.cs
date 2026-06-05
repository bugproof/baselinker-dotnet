using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.CourierShipments;

/// <summary>
/// This method allows to get detailed information about a package. If the package contains multiple subpackages,
/// information about all of them is included in the response.
/// </summary>
public class GetPackageDetails : IRequest<GetPackageDetails.Response>
{
    /// <summary>
    /// Shipment ID
    /// </summary>
    [JsonPropertyName("package_id")]
    public int PackageId { get; set; }

    public class PackageDetail
    {
        /// <summary>
        /// Package weight
        /// </summary>
        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        /// <summary>
        /// Unit of package weight ("kg", "g", "lb", "oz", "")
        /// </summary>
        [JsonPropertyName("weight_unit")]
        public string WeightUnit { get; set; }

        /// <summary>
        /// Package length
        /// </summary>
        [JsonPropertyName("length")]
        public double Length { get; set; }

        /// <summary>
        /// Package width
        /// </summary>
        [JsonPropertyName("width")]
        public double Width { get; set; }

        /// <summary>
        /// Package height
        /// </summary>
        [JsonPropertyName("height")]
        public double Height { get; set; }

        /// <summary>
        /// Unit of package size ("cm", "in", "")
        /// </summary>
        [JsonPropertyName("size_unit")]
        public string SizeUnit { get; set; }

        /// <summary>
        /// Size template identifier if used, otherwise empty
        /// </summary>
        [JsonPropertyName("size_template")]
        public string SizeTemplate { get; set; }

        /// <summary>
        /// True if package dimensions are custom, false otherwise
        /// </summary>
        [JsonPropertyName("is_custom")]
        public bool IsCustom { get; set; }

        /// <summary>
        /// Cash on delivery (COD) value
        /// </summary>
        [JsonPropertyName("cod_value")]
        public double CodValue { get; set; }

        /// <summary>
        /// Currency of COD value
        /// </summary>
        [JsonPropertyName("cod_currency")]
        public string CodCurrency { get; set; }

        /// <summary>
        /// Insurance value of the package
        /// </summary>
        [JsonPropertyName("insurance_value")]
        public double InsuranceValue { get; set; }

        /// <summary>
        /// Currency of insurance value
        /// </summary>
        [JsonPropertyName("insurance_currency")]
        public string InsuranceCurrency { get; set; }

        /// <summary>
        /// Shipping cost declared for the package
        /// </summary>
        [JsonPropertyName("cost_value")]
        public double CostValue { get; set; }

        /// <summary>
        /// Currency of shipping cost
        /// </summary>
        [JsonPropertyName("cost_currency")]
        public string CostCurrency { get; set; }

        /// <summary>
        /// Type of packaging used ("package", "dox", "pallet", "")
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Date of dispatch (unix time format)
        /// </summary>
        [JsonPropertyName("pickup_date")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset PickupDate { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("package_details")]
        public List<PackageDetail> PackageDetails { get; set; }
    }
}
