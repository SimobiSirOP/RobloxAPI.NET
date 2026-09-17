using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.RobloxObjects.Users;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UsersApi;

[NoAuth]
[UserCookieAuth]
internal class GetUsersFromIdsRequest : OldListRequestBase<RobloxUser[]>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore] public override string RequestPath { get; } = "https://users.roblox.com/v1/usernames/users";

    [JsonPropertyName("userIds")] public long[]? UserIds { get; set; }

    [JsonPropertyName("excludeBannedUsers")]
    public bool? ExcludeBannedUsers { get; set; }
}