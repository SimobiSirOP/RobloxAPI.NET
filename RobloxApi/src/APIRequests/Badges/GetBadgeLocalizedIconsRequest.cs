using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.RobloxObjects.Badges;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.Badges;

public class GetBadgeIconsRequest : OldListRequestBase<OldListResponseBase<RobloxBadgeIcon>>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/legacy-game-internationalization/v1/badges/{BadgeId}/icons";
    
    [JsonIgnore]
    public long BadgeId { get; set; }
}