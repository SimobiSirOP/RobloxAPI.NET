using System.Text.Json.Serialization;
using JetBrains.Annotations;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.APITypes.RobloxGeneralTypes;
using RobloxCloudApi.APITypes.RobloxObjects.Universe;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.LuauExecution;

[ApiTokenAuth]
internal class CreateLuauExecutionRequest : RequestBase<LuauExecutionOperation>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;
    
    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/places/{PlaceId}/luau-execution-session-tasks";

    [JsonIgnore] 
    public long UniverseId { get; set; }

    [JsonIgnore] 
    public long PlaceId { get; set; }

    [JsonPropertyName("script")] 
    public string? Script { get; set; }

    [JsonPropertyName("timeout")] 
    public RobloxDuration Timeout { get; set; }

    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Error { get; set; }

    [JsonPropertyName("output")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Output { get; set; }

    [JsonPropertyName("binaryInput")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RobloxBinary? BinaryInput { get; set; }

    [JsonPropertyName("enableBinaryOutput")]
    public bool EnableBinaryOutput { get; set; }
}