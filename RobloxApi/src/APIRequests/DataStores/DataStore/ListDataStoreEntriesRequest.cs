using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.DataStores;

[ApiTokenAuth]
internal class ListDataStoreEntriesRequest : ListRequestBase<DataStoreEntryList>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath
    {
        get
        {
            if (ScopeId == null)
                return
                    $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/entries";
            return
                $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}/scopes/{ScopeId}/entries";
        }
    }

    [JsonIgnore] public long? UniverseId { get; set; }

    [JsonIgnore] public string? DataStoreId { get; set; }

    [JsonIgnore] public string? ScopeId { get; set; }
}