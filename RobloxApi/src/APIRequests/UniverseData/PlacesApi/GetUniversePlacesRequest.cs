using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes.RobloxObjects.Universe;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UniverseData.PlacesApi;

// No auth
public class GetUniversePlacesRequest : OldListRequestBase<OldListResponseBase<PlaceInfo>>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    [JsonIgnore]
    public override string RequestPath => $"https://develop.roblox.com/v1/universes/{UniverseId}/places";

    [JsonIgnore] public long? UniverseId { get; set; }

    [QueryParameter("isUniverseCreation")] public bool? IsUniverseCreation { get; set; }
}