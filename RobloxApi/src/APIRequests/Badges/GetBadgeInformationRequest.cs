using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.RobloxObjects.Badges;

namespace RobloxCloudApi.APIRequests.Badges;


public class GetBadgeInformationRequest : RequestBase<RobloxBadge>
{
    [JsonIgnore] public override HttpMethod HttpMethod => HttpMethod.Get;

    [JsonIgnore] public override string RequestPath => $"https://badges.roblox.com/v1/badges/{BadgeId}";
    
    [JsonIgnore]
    public long BadgeId  { get; set; }
}