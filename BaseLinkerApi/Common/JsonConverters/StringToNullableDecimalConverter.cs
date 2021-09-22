using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BaseLinkerApi.Common.JsonConverters
{
    internal class StringToNullableDecimalConverter : JsonConverter<decimal?>
    {
        public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType switch
            {
                JsonTokenType.Number => reader.GetDecimal(),
                JsonTokenType.String => null, // could do decimal.TryParse?
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteNumberValue(value.Value);
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}