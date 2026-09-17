using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.DataStores.OrderedDataStore;

[ApiTokenAuth]
internal class CreateOrderedDataStoreEntryRequest : RequestBase<OrderedDataStoreEntry>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonPropertyName("path")]
    public override string RequestPath =>
                $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/ordered-data-stores/{OrderedDataStoreId}/scopes/{ScopeId}/entries";


    [JsonIgnore] public long UniverseId { get; set; }

    [JsonIgnore] public string OrderedDataStoreId { get; set; } = "";

    [JsonIgnore] [QueryParameter("id")] public string? EntryId { get; set; }

    [JsonIgnore] public string ScopeId { get; set; }  = "";
    
    [JsonPropertyName("value")] public long Value { get; set; }
    
}