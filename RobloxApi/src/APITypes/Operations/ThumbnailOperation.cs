using System.Text.Json;
using RobloxCloudApi.APITypes.RobloxGeneralTypes;

namespace RobloxCloudApi.APITypes.Operations;

public class ThumbnailOperation : RobloxOperation
{
    public string? ImageUri => ((JsonElement?)Result?.PropData?["imageUri"])?.ToString();
}