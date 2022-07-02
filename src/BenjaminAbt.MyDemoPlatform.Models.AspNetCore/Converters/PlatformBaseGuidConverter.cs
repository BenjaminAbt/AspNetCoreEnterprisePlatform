using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BenjaminAbt.MyDemoPlatform.Models.AspNetCore.Converters;

public class PlatformBaseGuidConverter<T> : JsonConverter<T> where T : PlatformBaseGuid, new()
{
    public override T Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string stringValue = reader.GetString();

            if (PlatformGuidFactory<T>.TryParse(stringValue, out T? id))
            {
                return id;
            }
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
