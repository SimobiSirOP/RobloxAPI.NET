using System.Text.Json.Serialization;

namespace RobloxCloudApi.APITypes.TypeBases;

/// <summary>
///     Use <see cref="List" /> to get an array of objects
/// </summary>
/// <typeparam name="T">An object of a list.</typeparam>
public abstract class ListResponseBase<T>
{
    [JsonPropertyName("nextPageToken")] public string? NextPageToken { get; set; }

    [JsonIgnore] public abstract T[]? List { get; set; }

    public T[]? AsArray()
    {
        if (List == null) return null;
        return List;
    }
}