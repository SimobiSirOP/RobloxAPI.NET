using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UsersApi;

[NoAuth]
[UserCookieAuth]
internal class ValidateDisplayNameNewUserRequest : RequestBase<object>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore] public override string RequestPath => "https://users.roblox.com/v1/display-names/validate";

    [QueryParameter("displayName")] public required string DisplayName { get; set; }
}