using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BaseLinkerApi.Common.JsonConverters;

internal class ByteArrayToBase64WithPrefixConverter  : JsonConverter<byte[]>
{
    public override byte[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotSupportedException();
        // var base64WithPrefix = reader.GetString();
        // var base64 = base64WithPrefix.Replace("data:", "");
        // return Convert.FromBase64String(base64);
    }

    public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"data:{Convert.ToBase64String(value)}");
    }
}