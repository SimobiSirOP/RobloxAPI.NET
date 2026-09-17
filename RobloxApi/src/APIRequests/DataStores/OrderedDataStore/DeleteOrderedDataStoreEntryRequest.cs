using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.DataStores.OrderedDataStore;

[ApiTokenAuth]
internal class DeleteOrderedDataStoreEntryRequest : RequestBase<object>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Delete;

    [JsonPropertyName("path")]
    public override string RequestPath =>
                $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/ordered-data-stores/{OrderedDataStoreId}/scopes/{ScopeId}/entries/{EntryId}";


    [JsonIgnore] public long UniverseId { get; set; }

    [JsonIgnore] public string OrderedDataStoreId { get; set; } = "";

    [JsonIgnore] public string? EntryId { get; set; }

    [JsonIgnore] public string ScopeId { get; set; }  = "";
}