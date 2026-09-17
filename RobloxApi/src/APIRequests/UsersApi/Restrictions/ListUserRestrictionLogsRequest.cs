using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.RobloxObjects.Users;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UsersApi.Restrictions;

[ApiTokenAuth]
internal class ListUserRestrictionLogsRequest : ListRequestBase<RestrictionList>
{
    [JsonIgnore] public long? UniverseId;

    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions";

    [JsonPropertyName("userRestrictions")] public RestrictionData[]? Restrictions { get; set; }
}