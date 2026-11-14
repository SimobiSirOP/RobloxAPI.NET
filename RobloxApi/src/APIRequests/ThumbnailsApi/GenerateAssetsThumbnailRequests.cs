using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.Thumbnails;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UsersApi;

[NoAuth]
[UserCookieAuth]
internal class GenerateAssetsThumbnailRequests : OldListRequestBase<OldListResponseBase<ThumbnailImageData>>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod => HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath => $"https://thumbnails.roblox.com/v1/assets";
    
    [QueryParameter("assetIds")]
    public long[]? AssetIds { get; set; }
    
    [QueryParameter("returnPolicy")]
    [QueryEnumToString]
    public RobloxThumbnailReturnPolicy ReturnPolicy { get; set; }
     
    [QueryParameter("includeBackground")]
    public bool IncludeBackground { get; set; } = true;

    [JsonIgnore] 
    public RobloxAssetsV1ThumbnailSize? Size;
    

    [QueryParameter("size")] 
    [QueryEnumToString]
    public string? SizeString => Size?.ToString()[4..];
    
    [QueryParameter("format")]
    [QueryEnumToString]
    public RobloxThumbnailFormat? Format { get; set; }
    
    [QueryParameter("isCircular")]
    public bool IsCircular { get; set; } = false;
    

   

}