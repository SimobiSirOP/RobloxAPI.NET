using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UsersApi;

[UserCookieAuth]
internal class ValidateDisplayNameExistingUserRequest : RequestBase<object>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath => $"https://users.roblox.com/v1/users/{UserId}/display-names/validate";

    public long UserId { get; set; }

    [QueryParameter("displayName")] public required string DisplayName { get; set; }
}