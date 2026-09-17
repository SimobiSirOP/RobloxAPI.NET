using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;

namespace RobloxCloudApi.APITypes.RobloxObjects.Universe;

public class LuauExecutionLog : ApiBaseData
{
    [JsonPropertyName("messages")] public RobloxMessage[]? Messages { get; set; }

    [JsonPropertyName("structuredMessages")]
    public RobloxStructuredMessage[]? StructuredMessages { get; set; }
}

public enum LuauLogView
{
    VIEW_UNSPECIFIED,
    FLAT,
    STRUCTURED
}