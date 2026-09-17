using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.APITypes.RobloxGeneralTypes;
using RobloxCloudApi.Helpers.JsonConverters;

namespace RobloxCloudApi.APITypes.RobloxObjects.Universe;

public class LuauExecutionOperation : BaseOperation
{
    [JsonPropertyName("createTime")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("updateTime")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? UpdateTime { get; set; }

    [JsonPropertyName("user")]
    public long? UserId { get; set; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LuauExecutionState? State { get; set; }

    [JsonPropertyName("script")] public string? Script { get; set; }

    [JsonPropertyName("timeout")] public RobloxDuration? Timeout { get; set; }

    [JsonPropertyName("error")] public RobloxError? Error { get; set; }

    [JsonPropertyName("output")] public object? Output { get; set; }

    [JsonPropertyName("binaryInput")] public RobloxBinary? BinaryInput { get; set; }

    [JsonPropertyName("enableBinaryOutput")]
    public bool? EnableBinaryOutput { get; set; }

    [JsonPropertyName("binaryOutputUrl")] public string? BinaryOutputUrl { get; set; }


    public override bool IsCompleted()
    {
        return State != LuauExecutionState.PROCESSING;
    }

    public string GetErrorString()
    {
        if (Error == null)
            return "No error specified";
        return Error.ToString();
    }
}

public enum LuauExecutionState
{
    STATE_UNSPECIFIED,
    PROCESSING,
    FAILED,
    COMPLETE
}