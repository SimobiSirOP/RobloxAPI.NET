using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.Badges;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.Badges;

[NoAuth]
[UserCookieAuth]
public class GetMultipleBadgeIconsRequest : RequestBase<OldListResponseBase<RobloxBadgeIcon>>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    public override string RequestPath => "https://thumbnails.roblox.com/v1/badges/icons";
    
    [QueryParameter("badgeIds")] 
    [JsonIgnore]
    public long[]? BadgeIds { get; set; }

    [QueryParameter("size")] 
    [JsonIgnore]
    public string? Size => "150x150"; // the only value in documentation
    
    [QueryParameter("isCircular")] 
    [JsonIgnore]
    public bool IsCircular { get; set; } = true;
    
    /// <summary>
    /// Supported formats: PNG, WEBP
    /// </summary>
    [JsonIgnore]
    public RobloxThumbnailFormat Format { get; set; } = RobloxThumbnailFormat.PNG;
    
    [QueryParameter("format")]
    [QueryEnumToString]
    [JsonIgnore]
    public string FormatString
    {
        get
        {
            var strFormat = Format.ToString();
            return char.ToUpper(strFormat[0]) + strFormat.Substring(1).ToLower();
        }
    }

    

}