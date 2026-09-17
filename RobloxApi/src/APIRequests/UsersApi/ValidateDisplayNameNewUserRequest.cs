using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UsersApi;

[NoAuth]
[UserCookieAuth]
public class ValidateDisplayNameNewUserRequest : RequestBase<object>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    public override string RequestPath => "https://users.roblox.com/v1/display-names/validate";

    [QueryParameter("displayName")] public required string DisplayName { get; set; }
}