using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.Badges;

[ApiTokenAuth]
public class UpdateBadgeLocalizedIconRequest : RequestBase<object>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/legacy-game-internationalization/v1/badges/{BadgeId}/icons/language-codes/{LanguageCode}";
    
    [JsonIgnore]
    public long BadgeId { get; set; }
    
    [JsonIgnore]
    public string? LanguageCode { get; set; }
    
    
    [JsonIgnore]
    public byte[]? Icon { get; set; }

    public override HttpContent? GetHttpContent()
    {
        var content = new MultipartFormDataContent();
        if (Icon == null)
            throw new ArgumentNullException(nameof(Icon));
        content.Add(new ByteArrayContent(Icon));

        return content;
    }
}