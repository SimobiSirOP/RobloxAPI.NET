using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.DataStores;

[ApiTokenAuth]
internal class GetDataStoreEntryRequest : RequestBase<DataStoreEntry>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
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

    [JsonIgnore] public string? EntryId { get; set; }

    [JsonIgnore] public string? ScopeId { get; set; }
}