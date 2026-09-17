using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;

namespace RobloxCloudApi.APITypes.TypeBases;

internal abstract class ListRequestBase<T> : RequestBase<T>
{
    [JsonIgnore] public abstract override HttpMethod HttpMethod { get; }

    [JsonPropertyName("path")] public abstract override string RequestPath { get; }

    [QueryParameter("maxPageSize")] public int? MaxPageSize { get; set; } = 10;

    [QueryParameter("pageToken", true)] public string? PageToken { get; set; }

    [QueryParameter("showDeleted")] public bool? ShowDeleted { get; set; }
    
    [QueryParameter("filter", true)] public string? Filter { get; set; }
}