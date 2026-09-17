using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.DataStores;

[ApiTokenAuth]
internal class ListDataStoresRequest : ListRequestBase<DataStoreList>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores";

    [JsonIgnore] public long? UniverseId { get; set; }
}