using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;
using RobloxCloudApi.APITypes.TypeBases;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.APIRequests.DataStores;

[ApiTokenAuth]
internal class UpdateDataStoreEntryRequest : RequestBase<DataStoreEntry>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Patch;

    [JsonPropertyName("path")]
    public override string RequestPath
    {
        get
        {
            if (ScopeId == null)
                return
                    $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/entries/{EntryId}";
            return
                $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/scopes/{ScopeId}/entries/{EntryId}";
        }
    }

    [JsonIgnore] public long? UniverseId { get; set; }

    [JsonIgnore] public string? DataStoreId { get; set; }

    [JsonPropertyName("id")] public string? EntryId { get; set; }

    [JsonIgnore] public string? ScopeId { get; set; }

    [JsonIgnore]
    [QueryParameter("allowMissing")]
    public bool? AllowMissing { get; set; }

    [JsonPropertyName("etag")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ETag { get; set; }

    [JsonPropertyName("value")] public object? Value { get; set; }

    [JsonPropertyName("users")]
    [JsonConverter(typeof(UserApiPathArrayConverter))]
    public long[]? Users { get; set; }

    [JsonPropertyName("attributes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Attributes { get; set; }
}