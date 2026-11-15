using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APITypes.RobloxObjects.Users;

public class RestrictionLogList : ListResponseBase<RestrictionDataLog>
{
    [JsonPropertyName("logs")]
    public override RestrictionDataLog[]? List { get; set; }
}