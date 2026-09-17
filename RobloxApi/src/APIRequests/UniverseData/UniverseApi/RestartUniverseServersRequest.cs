using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UniverseData.UniverseApi;

[ApiTokenAuth]
public class RestartUniverseServersRequest : RequestBase<object>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}:restartServers";
    
    [JsonIgnore]
    public long UniverseId { get; set; }
    
   
    [JsonPropertyName("placeIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long[]? PlaceIds { get; set; }
    
    [JsonPropertyName("closeAllVersions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CloseAllVersions { get; set; }
    
    [JsonPropertyName("bleedOffServers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BleedOffServers { get; set; }
    
    [JsonPropertyName("bleedOffDurationMinutes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? BleedOffDurationMinutes { get; set; }
    
}