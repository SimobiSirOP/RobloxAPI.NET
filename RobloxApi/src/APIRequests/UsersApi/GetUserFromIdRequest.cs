using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.RobloxObjects.Users;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UsersApi;

[ApiTokenAuth]
public class GetUserFromIdRequest : RequestBase<RobloxFullUser>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore] public override string RequestPath => $"https://apis.roblox.com/cloud/v2/users/{UserId}";

    [JsonPropertyName("id")] public long? UserId { get; set; }
}