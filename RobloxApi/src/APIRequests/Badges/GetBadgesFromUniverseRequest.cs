using System.Text.Json.Serialization;
using JetBrains.Annotations;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.RobloxObjects.Badges;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.Badges;

[UserCookieAuth]
[NoAuth]
public class GetBadgesFromUniverseRequest : OldListRequestBase<OldListResponseBase<RobloxBadge>>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore] public override string RequestPath => $"https://badges.roblox.com/v1/universes/{UniverseId}/badges";
    
    [JsonIgnore]
    public long UniverseId { get; set; }

    [QueryParameter("sortOrder")]
    [QueryEnumToString]
    public BadgesSortOrder SortOrder { get; set; }


    public enum BadgesSortOrder
    {
        Rank,
        DateCreated
    }
}