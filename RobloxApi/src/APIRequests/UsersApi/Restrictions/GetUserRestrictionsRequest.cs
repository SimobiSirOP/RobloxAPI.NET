using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.RobloxObjects.Users;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UsersApi.Restrictions;

[ApiTokenAuth]
internal class GetUserRestrictionsRequest : RequestBase<RestrictionData>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonPropertyName("path")]
    public override string RequestPath =>
        $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions/{UserId}";

    public long? UniverseId { get; set; }

    public long? UserId { get; set; }
}