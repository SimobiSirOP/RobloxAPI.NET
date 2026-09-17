using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.DataStores;

[ApiTokenAuth]
internal class DeleteDataStoreRequest : RequestBase<DataStoreInfo>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Delete;

    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores/{DataStoreId}";

    [JsonIgnore] public long? UniverseId { get; set; }

    [JsonIgnore] public string? DataStoreId { get; set; }
}