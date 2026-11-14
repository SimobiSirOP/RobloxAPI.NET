using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.APITypes.RobloxObjects.Thumbnails;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UsersApi;

[UserCookieAuth]
[NoAuth]
internal class GenerateFullBodyThumbnailRequest : OldListRequestBase<OldListResponseBase<ThumbnailImageData>>
{
    public override HttpMethod HttpMethod => HttpMethod.Get;

    public override string RequestPath => $"https://thumbnails.roblox.com/v1/users/avatar";
    
    [QueryParameter("userIds")]
    public long[]? UserIds { get; set; }
    
    [QueryParameter("includeBackground")]
    public bool IncludeBackground { get; set; } = true;

    [JsonIgnore] 
    public RobloxFullBodyThumbnailSize? Size;

    [QueryParameter("size")] 
    public string? SizeString => Size?.ToString()[4..]; // Skips size coz enum conf limits
    
    [QueryParameter("format")]
    [QueryEnumToString]
    public RobloxThumbnailFormat? Format { get; set; }
    
    [QueryParameter("isCircular")]
    public bool IsCircular { get; set; } = false;
    
    

}