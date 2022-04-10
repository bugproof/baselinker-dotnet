using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BaseLinkerApi.Common.JsonConverters;

internal class BoolConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.True or JsonTokenType.False:
                return reader.GetBoolean();
            case JsonTokenType.Number when reader.TryGetInt32(out var i):
                return i == 1;
            default:
            {
                var str = reader.GetString()?.ToLowerInvariant();
                return str is "true" or "1";
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        // Still unsure about this
        writer.WriteBooleanValue(value);
    }
}