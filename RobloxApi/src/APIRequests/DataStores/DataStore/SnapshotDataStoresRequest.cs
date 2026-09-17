using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.TypeBases;
using RobloxCloudApi.Helpers.JsonConverters;

namespace RobloxCloudApi.APIRequests.DataStores;

[ApiTokenAuth]
internal class SnapshotDataStoresRequest : RequestBase<SnapshotResult>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore]
    public override string RequestPath =>
        $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}/data-stores:snapshot";

    [JsonIgnore] public long? UniverseId { get; set; }
}

public class SnapshotResult
{
    [JsonPropertyName("newShapshotTaken")] public bool? NewSnapshotTaken { get; set; }

    [JsonPropertyName("latestSnapshotTaken")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? LatestSnapshotTaken { get; set; }
}