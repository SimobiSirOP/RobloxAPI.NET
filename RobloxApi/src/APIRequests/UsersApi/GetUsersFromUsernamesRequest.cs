using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.RobloxObjects.Users;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UsersApi;


[NoAuth]
[UserCookieAuth]
public class GetUsersFromUsernamesRequest : OldListRequestBase<OldListResponseBase<RobloxUser>>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore] public override string RequestPath { get; } = "https://users.roblox.com/v1/usernames/users";

    [JsonPropertyName("usernames")] public string[]? Usernames { get; set; }

    [JsonPropertyName("excludeBannedUsers")]
    public bool? ExcludeBannedUsers { get; set; }
}