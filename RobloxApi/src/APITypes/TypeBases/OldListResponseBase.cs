using System.Text.Json.Serialization;

namespace RobloxCloudApi.APITypes.TypeBases;

public class OldListResponseBase<T>
{
    [JsonPropertyName("previousPageCursor")]
    public string? PreviousPageCursor { get; set; }

    [JsonPropertyName("nextPageCursor")] public string? NextPageCursor { get; set; }

    [JsonPropertyName("data")] public virtual T[]? List { get; set; }

    public T[]? AsArray()
    {
        if (List == null) return null;
        return List;
    }
}