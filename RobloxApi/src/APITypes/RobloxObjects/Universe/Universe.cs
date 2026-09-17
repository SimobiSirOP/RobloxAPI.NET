using System.Text.Json.Serialization;
using RobloxCloudApi.Helpers.JsonConverters;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.APITypes.RobloxObjects.Universe;

public class RobloxUniverse 
{
    [JsonPropertyName("path")]
    [JsonConverter(typeof(UniverseApiPathConverter))]
    public long UniverseId { get; set; }
    
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    [JsonPropertyName("createTime")]
    public DateTime? CreationTime { get; set; }
    
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    [JsonPropertyName("updateTime")]
    public DateTime? UpdateTime { get; set; }
    
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("user")]
    public string? User { get; set; }
    
    [JsonPropertyName("group")]
    public string? Group { get; set; }
    
    [JsonPropertyName("visibility")]
    [JsonConverter(typeof(JsonStringEnumConverter<UniverseVisibility>))]
    public UniverseVisibility? Visibility { get; set; }
    
    [JsonPropertyName("facebookSocialLink")]
    public SocialLink? FacebookSocialLink { get; set; }
    
    [JsonPropertyName("twitterSocialLink")]
    public SocialLink? TwitterSocialLink { get; set; }
    
    [JsonPropertyName("youtubeSocialLink")]
    public SocialLink? YoutubeSocialLink { get; set; }
    
    [JsonPropertyName("twitchSocialLink")]
    public SocialLink? TwitchSocialLink { get; set; }
    
    [JsonPropertyName("discordSocialLink")]
    public SocialLink? DiscordSocialLink { get; set; }
    
    [JsonPropertyName("robloxGroupSocialLink")]
    public SocialLink? RobloxGroupSocialLink { get; set; }
    
    [JsonPropertyName("guildedSocialLink")]
    public SocialLink? GuildedSocialLink { get; set; }
    
    [JsonPropertyName("voiceChatEnabled")]
    public bool? VoiceChatEnabled { get; set; }
    
    [JsonPropertyName("ageRating")]
    public string? AgeRating { get; set; }
    
    [JsonPropertyName("privateServerPriceRobux")]
    public long? PrivateServerPriceRobux { get; set; }
    
    [JsonPropertyName("desktopEnabled")]
    public bool? DesktopEnabled { get; set; }
    
    [JsonPropertyName("mobileEnabled")]
    public bool? MobileEnabled { get; set; }
    
    [JsonPropertyName("tabletEnabled")]
    public bool? TabletEnabled { get; set; }
    
    [JsonPropertyName("consoleEnabled")]
    public bool? ConsoleEnabled { get; set; }
    
    [JsonPropertyName("vrEnabled")]
    public bool? VrEnabled { get; set; }
    
    [JsonPropertyName("rootPlace")]
    public string? RootPlace { get; set; }
    
    
    public enum UniverseVisibility
    {
        PUBLIC,
        PRIVATE,
        FRIENDS_ONLY
    }

    public enum UniverseAgeRating
    {
        AGE_RATING_UNSPECIFIED
    }

    public struct SocialLink
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }
    }
}