using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.DataStores.OrderedDataStore;

[ApiTokenAuth]
internal class ListOrderedDataStoreEntriesRequest : ListRequestBase<OrderedDataStoreEntryList>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonPropertyName("path")]
    public override string RequestPath =>
                $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/ordered-data-stores/{OrderedDataStoreId}/scopes/{ScopeId}/entries";


    [JsonIgnore] public long UniverseId { get; set; }

    [JsonIgnore] public string OrderedDataStoreId { get; set; } = "";

    [JsonIgnore] public string ScopeId { get; set; }  = "";
}