using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.Operations;

namespace RobloxCloudApi.APITypes.RobloxObjects.Thumbnails;

public class ThumbnailImageData : BaseOperation
{
    [JsonPropertyName("targetId")] public long TargetId { get; set; }

    [JsonPropertyName("imageUrl")] public string? ImageUrl { get; set; }

    [JsonPropertyName("state")] public string? State { get; set; }

    [JsonPropertyName("version")] public string? Version { get; set; }

    public override bool IsCompleted()
    {
        return State == "Completed";
    }
}