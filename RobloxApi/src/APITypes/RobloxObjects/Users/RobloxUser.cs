using System.Text.Json.Serialization;

namespace RobloxCloudApi.APITypes.RobloxObjects.Users;

public class RobloxUser
{
    [JsonPropertyName("hasVerifiedBadge")] public bool VerifiedBadge { get; set; }

    [JsonPropertyName("id")] public long UserId { get; set; }

    [JsonPropertyName("name")] public string? Username { get; set; }

    [JsonPropertyName("displayName")] public string? DisplayName { get; set; }
}