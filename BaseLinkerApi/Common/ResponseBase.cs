using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BaseLinkerApi.Common;

internal class StatusConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() == "SUCCESS";
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) => throw new NotSupportedException();
}

public class ResponseBase
{
    [JsonPropertyName("status")]
    [JsonConverter(typeof(StatusConverter))]
    public bool IsSuccessStatus { get; set; }
        
    [JsonPropertyName("error_message")] 
    public string? ErrorMessage { get; set; }
        
    [JsonPropertyName("error_code")] 
    public string? ErrorCode { get; set; }
}