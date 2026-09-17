using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.Universe;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UniverseData.UniverseApi;

[ApiTokenAuth]
public class GetUniverseRequest : RequestBase<RobloxUniverse>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}";
    
    [JsonIgnore]
    public long UniverseId { get; set; }
}