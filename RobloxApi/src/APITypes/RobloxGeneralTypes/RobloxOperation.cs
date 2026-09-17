using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.Operations;

namespace RobloxCloudApi.APITypes.RobloxGeneralTypes;

public class RobloxOperation : BaseOperation
{
    [JsonPropertyName("done")] public bool? Done { get; set; }

    [JsonPropertyName("metadata")] public RobloxDetails? Metadata { get; set; }

    [JsonPropertyName("error")] public RobloxError? Error { get; set; }

    [JsonPropertyName("response")] public RobloxDetails? Result { get; set; }

    public override bool IsCompleted()
    {
        return Done ?? false;
    }
}