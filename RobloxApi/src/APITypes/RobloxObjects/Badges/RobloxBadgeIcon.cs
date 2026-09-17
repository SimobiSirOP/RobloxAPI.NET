using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.Operations;

namespace RobloxCloudApi.APITypes.RobloxObjects.Badges;

public class RobloxBadgeIcon : BaseOperation
{
    [JsonPropertyName("imageId")] 
    public string ImageId { get; set; }
    
    [JsonPropertyName("imageUrl")] 
    public string ImageUrl { get; set; }
    
    [JsonPropertyName("state")] 
    public string State { get; set; }
    
    [JsonPropertyName("languageCode")] 
    public string LanguageCode { get; set; }
    
    /// <summary>
    /// Can be null, used in <see cref="RobloxCloudApi.APIRequests.Badges.GetMultipleBadgeIconsRequest"/>
    /// </summary>
    [JsonPropertyName("targetId")]
    public long? TargetId { get; set; }

    public override bool IsCompleted()
    {
        return State == "Completed";
    }
}