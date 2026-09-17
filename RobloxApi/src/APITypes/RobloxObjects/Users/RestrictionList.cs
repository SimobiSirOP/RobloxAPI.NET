using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APITypes.RobloxObjects.Users;

public class RestrictionList : ListResponseBase<RestrictionData>
{
    [JsonPropertyName("userRestrictions")] public override RestrictionData[]? List { get; set; }
}