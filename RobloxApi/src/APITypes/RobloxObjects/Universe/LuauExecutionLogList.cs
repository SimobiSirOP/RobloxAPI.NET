using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APITypes.RobloxObjects.Universe;

public class LuauExecutionLogList : ListResponseBase<LuauExecutionLog>
{
    [JsonPropertyName("luauExecutionSessionTaskLogs")]
    public override LuauExecutionLog[]? List { get; set; }
}