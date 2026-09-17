using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;

namespace RobloxCloudApi.APIRequests.Badges;


public class UpdateBadgeLocalizedDescriptionRequest : RequestBase<string>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Patch;

    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/legacy-game-internationalization/v1/badges/{BadgeId}/description/language-codes/{LanguageCode}";
    
    [JsonIgnore]
    public long BadgeId { get; set; }
    
    [JsonIgnore]
    public string? LanguageCode { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    
}