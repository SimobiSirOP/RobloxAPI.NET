using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;
using RobloxCloudApi.APITypes.TypeBases;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.APIRequests.DataStores;

[ApiTokenAuth]
internal class IncrementDataStoreEntryRequest : RequestBase<DataStoreEntry>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonPropertyName("path")]
    public override string RequestPath
    {
        get
        {
            if (ScopeId == null)
                return
                    $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/entries/{EntryId}:increment";
            return
                $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/scopes/{ScopeId}/entries/{EntryId}:increment";
        }
    }

    [JsonIgnore] public long? UniverseId { get; set; }

    [JsonIgnore] public string? DataStoreId { get; set; }

    [JsonIgnore] public string? EntryId { get; set; }

    [JsonIgnore] public string? ScopeId { get; set; }

    [JsonPropertyName("amount")] public long? Amount { get; set; }

    [JsonPropertyName("users")]
    [JsonConverter(typeof(UserApiPathArrayConverter))]
    public long[]? Users { get; set; }

    [JsonPropertyName("attributes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Attributes { get; set; }
}