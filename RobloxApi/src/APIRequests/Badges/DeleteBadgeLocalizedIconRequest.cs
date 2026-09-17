using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;

namespace RobloxCloudApi.APIRequests.Badges;

public class DeleteBadgeLocalizedIconRequest : RequestBase<object>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Delete;

    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/legacy-game-internationalization/v1/badges/{BadgeId}/icons/language-codes/{LanguageCode}";
    
    [JsonIgnore]
    public long BadgeId { get; set; }
    
    [JsonIgnore]
    public string? LanguageCode { get; set; }
}