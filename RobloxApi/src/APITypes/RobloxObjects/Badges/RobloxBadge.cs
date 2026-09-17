using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.RobloxObjects.Universe;
using RobloxCloudApi.Helpers.JsonConverters;

namespace RobloxCloudApi.APITypes.RobloxObjects.Badges;


public class RobloxBadge
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("description")] public string Description { get; set; }

    [JsonPropertyName("displayName")] public string DisplayName { get; set; }

    [JsonPropertyName("displayDescription")]
    public string DisplayDescription { get; set; }

    [JsonPropertyName("enabled")] public bool Enabled { get; set; }

    [JsonPropertyName("iconImageId")] public long IconImageId { get; set; }

    [JsonPropertyName("displayIconImageId")]
    public long DisplayIconImageId { get; set; }

    [JsonPropertyName("created")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime Created { get; set; }

    [JsonPropertyName("updated")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime Updated { get; set; }
    
    [JsonPropertyName("statistics")]
    public RobloxBadgeStatistics Statistics { get; set; }
    
    /// <summary>
    /// CAUTION. Contains only the id, name, and rootPlaceId of the universe that the badge is awarded in. 
    /// </summary>
    [JsonPropertyName("awardingUniverse")]
    public RobloxUniverse AwardingUniverse { get; set; }
}

public class RobloxBadgeStatistics
{
    [JsonPropertyName("pastDayAwardedCount")]
    public long PastDayAwardedCount { get; set; }
    
    [JsonPropertyName("awardedCount")]
    public long AwardedCount { get; set; }
    
    [JsonPropertyName("winRatePercentage")]
    public double WinRatePercentage { get; set; }
}
