using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.RobloxGeneralTypes;
using RobloxCloudApi.Helpers;
using RobloxCloudApi.Helpers.JsonConverters;

namespace RobloxCloudApi.APITypes;

public class RobloxMessage
{
    [JsonPropertyName("message")] public string? Message { get; set; }

    public override string ToString()
    {
        return "Message: " + Message;
    }
}

public class RobloxStructuredMessage : RobloxMessage
{
    [JsonPropertyName("createTime")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? CreateTime { get; set; }

    [JsonPropertyName("messageType")] public string? MessageType { get; set; }
}

public class RobloxError
{
    [JsonPropertyName("code")]
    [JsonConverter(typeof(NumberToStringConverter))]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("message")] public string? ErrorMessage { get; set; }

    [JsonPropertyName("details")] public RobloxDetails[]? Details { get; set; }

    public override string ToString()
    {
        var result = $"Error {ErrorCode}: {ErrorMessage}. ";

        if (Details != null)
            result += "\n Details: " + Serializer.SerializeToString(Details!);
        return result;
    }
}