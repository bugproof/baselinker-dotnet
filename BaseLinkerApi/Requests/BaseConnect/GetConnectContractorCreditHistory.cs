using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;

namespace BaseLinkerApi.Requests.BaseConnect;

/// <summary>
/// The method allows you to retrieve an information about chosen contractor trade credit history.
/// </summary>
public class GetConnectContractorCreditHistory : IRequest<GetConnectContractorCreditHistory.Response>
{
    /// <summary>
    /// Contractor ID
    /// </summary>
    [JsonPropertyName("contractor_id")]
    public int ContractorId { get; set; }

    [JsonPropertyName("token_id")]
    public int TokenId { get; set; }

    public class CreditEntry
    {
        /// <summary>
        /// Entry ID
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Entry add date in unix timestamp format
        /// </summary>
        [JsonPropertyName("date_add")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateAdd { get; set; }

        /// <summary>
        /// Entry description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Entry currency
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Entry type: charge / payment
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Entry amount
        /// </summary>
        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Entry status: 0 - waiting, 1 - active
        /// </summary>
        [JsonPropertyName("is_accepted")]
        public int IsAccepted { get; set; }
    }

    public class Response : ResponseBase
    {
        [JsonPropertyName("credit_data")]
        public List<CreditEntry> CreditData { get; set; }
    }
}
