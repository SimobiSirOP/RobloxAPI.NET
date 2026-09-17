using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.Helpers.JsonConverters;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.APITypes.RobloxObjects.Users;

public class RestrictionData : ApiBaseData
{
    [JsonPropertyName("gameJoinRestriction")]
    public GameJoinRestriction? GameJoinRestriction { get; set; }
    
    [JsonPropertyName("user")]
    [JsonConverter(typeof(UserApiPathConverter))]
    public long UserId { get; set; }
}

public class RestrictionDataLog : GameJoinRestriction
{
    [JsonPropertyName("updateTime")] [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? UpdateTime { get; set; }
    
    [JsonPropertyName("createTime")] [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? CreateTime { get; set; }
    
    [JsonPropertyName("moderator")]
    public Moderator? Moderator { get; set; }
}

public class Moderator
{
    [JsonPropertyName("robloxUser")]
    [JsonConverter(typeof(UserApiPathConverter))]
    public long UserId { get; set; }
    
    [JsonPropertyName("gameServerScript")] 
    public object? GameServerScript { get; set; }
}

public class GameJoinRestriction
{
    [JsonPropertyName("active")] 
    public bool? Active { get; set; }

    [JsonPropertyName("displayReason")] 
    public string? DisplayReason { get; set; }

    [JsonPropertyName("duration")] 
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Duration { get; set; }

    [JsonPropertyName("excludeAltAccounts")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ExcludeAltAccounts { get; set; }

    [JsonPropertyName("inherited")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Inherited { get; set; }

    [JsonPropertyName("privateReason")] 
    public string? PrivateReason { get; set; }

    [JsonPropertyName("startTime")] 
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? StartTime { get; set; }
}