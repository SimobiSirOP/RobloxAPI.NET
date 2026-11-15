using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace RobloxCloudApi.Helpers.JsonConverters;

internal class DateTimeIso8601Converter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read([NotNull] ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();
        if (string.IsNullOrEmpty(stringValue))
            return DateTimeOffset.MinValue;
        
        return DateTimeOffset.Parse(stringValue);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
    }
}