using RobloxCloudApi.APITypes.RobloxGeneralTypes;

namespace RobloxCloudApi.APITypes.Operations;

public class ThumbnailOperation : RobloxOperation
{
    string? ImageUri => (string?)Result.PropData["imageUri"];
}