using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.Badges;

[ApiTokenAuth]
public class UpdateBadgeLocalizedNameAndDescriptionRequest : RequestBase<string>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/legacy-game-internationalization/v1/badges/{BadgeId}/name-description/language-codes/{LanguageCode}";
    
    [JsonIgnore]
    public long BadgeId { get; set; }
    
    [JsonIgnore]
    public string? LanguageCode { get; set; }
    
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
}