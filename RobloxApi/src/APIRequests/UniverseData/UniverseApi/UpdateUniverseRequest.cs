using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.Universe;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APIRequests.UniverseData.UniverseApi;

[ApiTokenAuth]
public class UpdateUniverseRequest : RequestBase<RobloxUniverse>
{
    [JsonIgnore]
    public override HttpMethod HttpMethod { get; } = HttpMethod.Patch;
    [JsonIgnore]
    public override string RequestPath => $"https://apis.roblox.com/cloud/v2/universes/{UniverseId}";
    
    [JsonIgnore]
    public long UniverseId { get; set; }
    
    [JsonPropertyName("displayName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DisplayName { get; set; }
    
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }
    
    [JsonPropertyName("user")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? User { get; set; }
    
    [JsonPropertyName("group")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Group { get; set; }
    
    [JsonPropertyName("visibility")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(JsonStringEnumConverter<RobloxUniverse.UniverseVisibility>))]
    public RobloxUniverse.UniverseVisibility? Visibility { get; set; }
    
    [JsonPropertyName("facebookSocialLink")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RobloxUniverse.SocialLink? FacebookSocialLink { get; set; }
    
    [JsonPropertyName("twitterSocialLink")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RobloxUniverse.SocialLink? TwitterSocialLink { get; set; }
    
    [JsonPropertyName("youtubeSocialLink")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RobloxUniverse.SocialLink? YoutubeSocialLink { get; set; }
    
    [JsonPropertyName("twitchSocialLink")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RobloxUniverse.SocialLink? TwitchSocialLink { get; set; }
    
    [JsonPropertyName("discordSocialLink")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RobloxUniverse.SocialLink? DiscordSocialLink { get; set; }
    
    [JsonPropertyName("robloxGroupSocialLink")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RobloxUniverse.SocialLink? RobloxGroupSocialLink { get; set; }
    
    [JsonPropertyName("guildedSocialLink")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RobloxUniverse.SocialLink? GuildedSocialLink { get; set; }
    
    [JsonPropertyName("voiceChatEnabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? VoiceChatEnabled { get; set; }
    
    [JsonPropertyName("ageRating")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AgeRating { get; set; }
    
    [JsonPropertyName("privateServerPriceRobux")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? PrivateServerPriceRobux { get; set; }
    
    [JsonPropertyName("desktopEnabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DesktopEnabled { get; set; }
    
    [JsonPropertyName("mobileEnabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? MobileEnabled { get; set; }
    
    [JsonPropertyName("tabletEnabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? TabletEnabled { get; set; }
    
    [JsonPropertyName("consoleEnabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ConsoleEnabled { get; set; }
    
    [JsonPropertyName("vrEnabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? VrEnabled { get; set; }
    
    [JsonPropertyName("templateRootPlace")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TemplateRootPlace { get; set; }
    
}