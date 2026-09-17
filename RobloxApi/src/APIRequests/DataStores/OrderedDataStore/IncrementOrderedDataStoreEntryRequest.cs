using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.DataStores.OrderedDataStore;

[ApiTokenAuth]
public class IncrementOrderedDataStoreEntryRequest : RequestBase<OrderedDataStoreEntry>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonPropertyName("path")]
    public override string RequestPath =>
        $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/ordered-data-stores/{OrderedDataStoreId}/scopes/{ScopeId}/entries/{EntryId}:increment";


    [JsonIgnore] public long UniverseId { get; set; }

    [JsonIgnore] public string OrderedDataStoreId { get; set; } = "";

    [JsonIgnore] public string? EntryId { get; set; }

    [JsonIgnore] public string ScopeId { get; set; }  = "";
    
    [JsonPropertyName("amount")] public long Amount { get; set; }
}