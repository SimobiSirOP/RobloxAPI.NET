using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.DataStores;

[ApiTokenAuth]
internal class DeleteDataStoreEntryRequest : RequestBase<object>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Delete;

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