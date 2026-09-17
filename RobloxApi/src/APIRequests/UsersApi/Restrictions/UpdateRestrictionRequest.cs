using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.RobloxObjects.Users;
using RobloxCloudApi.APITypes.TypeBases;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.APIRequests.UsersApi.Restrictions;

[ApiTokenAuth]
internal class UpdateRestrictionRequest : RequestBase<RestrictionData>
{
    // Currently, Roblox has only gameJoinRestriction, that is just a ban
    [JsonPropertyName("gameJoinRestriction")]
    public GameJoinRestriction? GameJoinRestriction;

    [JsonIgnore] public long? UniverseId;

    [JsonPropertyName("user")] 
    [JsonConverter(typeof(UserApiPathConverter))]
    public long? UserId;

    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Patch;

    [JsonPropertyName("path")]
    public override string RequestPath =>
        $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/user-restrictions/{UserId}";
}