using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BenjaminAbt.MyDemoPlatform.Models.AspNetCore.Converters;

public class PlatformBaseGuidCollectionConverter<T> : JsonConverter<T[]>
{
    public override T[]? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("Expected StartArray token");
        }

        List<T> value = new(0);

        JsonConverter<T> converter = (JsonConverter<T>)options.GetConverter(typeof(T));
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                return value.ToArray();
            }

            T item = converter.Read(ref reader, typeToConvert, options);
            value.Add(item);
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, T[] value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, (object?)value, options);
}
