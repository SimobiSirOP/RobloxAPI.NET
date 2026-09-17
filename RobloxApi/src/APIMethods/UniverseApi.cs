using RobloxCloudApi.APIRequests.Badges;
using RobloxCloudApi.APIRequests.LuauExecution;
using RobloxCloudApi.APIRequests.UniverseData.PlacesApi;
using RobloxCloudApi.APIRequests.UniverseData.UniverseApi;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.APITypes.RobloxGeneralTypes;
using RobloxCloudApi.APITypes.RobloxObjects.Badges;
using RobloxCloudApi.APITypes.RobloxObjects.Universe;
using RobloxCloudApi.APITypes.TypeBases;
using RobloxCloudApi.ErrorHandling.Exceptions;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

public class UniverseApi
{
    private readonly IRobloxApiClient _client;

    public UniverseApi(IRobloxApiClient client)
    {
        this._client = client;
    }
    
    
    /// <summary>
    /// Get a list of places in a universe.
    /// </summary>
    /// <param name="universeId">A Roblox Universe ID</param>
    /// <param name="isUniverseCreation">Is a universe being created</param>
    /// <param name="maxPageSize">Maximum size of page list</param>
    /// <param name="cursor">Cursor to next page  of places list</param>
    /// <param name="sortOrder">Sort order of list of places</param>
    /// <returns>A instance of <see cref="PlaceInfoList"/></returns>
    public async Task<OldListResponseBase<PlaceInfo>> GetUniversePlaces(
        long universeId,
        bool? isUniverseCreation = false,
        int maxPageSize = 10,
        string? cursor = null,
        SortOrder sortOrder = SortOrder.Asc)
    {
        return (await _client.ThrowIfNull().SendRequest(new GetUniversePlacesRequest
        {
            UniverseId = universeId,
            IsUniverseCreation = isUniverseCreation,
            MaxPageSize = maxPageSize,
            Cursor = cursor,
            SortOrder = sortOrder
        }))!;
    }

    
    /// <summary>
    /// Get a universe
    /// </summary>
    /// <param name="universeId">A Roblox Universe ID</param>
    /// <returns>A instance of <see cref="RobloxUniverse" /></returns>
    public async Task<RobloxUniverse> GetUniverse( long universeId)
    {
        return (await _client.ThrowIfNull().SendRequest(
            new GetUniverseRequest()
            {
                UniverseId = universeId
            }))!;
    }
    
    
    /// <summary>
    /// Publishes a message to a universe
    /// </summary>
    /// <param name="universeId">A roblox universe id</param>
    /// <param name="message">A message to send</param>
    /// <param name="topic">Topic of the sent message</param>
    public async Task PublishUniverseMessage( long universeId, string message, string topic = "Unknown")
    {
        await _client.ThrowIfNull().SendRequest(
            new PublishUniverseMessageRequest()
            {
                UniverseId = universeId,
                Message = message,
                Topic = topic
            });
    }

    /// <summary>
    /// Restarts the universe's servers
    /// </summary>
    /// <param name="universeId">The ID of the universe</param>
    /// <param name="placeIds">Optional array of place IDs</param>
    /// <param name="closeAllVersions">Flag that specifies if all versions should be closed</param>
    /// <param name="bleedOffServer">Flag to bleed off servers.</param>
    /// <param name="bleedOffDurationMinutes">Duration in minutes for bleeding-off servers</param>
    /// <exception cref="RobloxApiException">Error that occurs during a request to Roblox API</exception>
    public async Task RestartUniverseServers(
        long universeId,
        long[]? placeIds = null,
        bool? closeAllVersions = null,
        bool? bleedOffServer = null,
        long? bleedOffDurationMinutes = null)
    {
        if (bleedOffServer != null && bleedOffDurationMinutes == null)
            throw new RobloxApiException("bleedOffDurationMinutes must be provided when bleedOffServer is true");

        await _client.ThrowIfNull().SendRequest(
            new RestartUniverseServersRequest()
            {
                BleedOffDurationMinutes = bleedOffDurationMinutes,
                BleedOffServers = bleedOffServer,
                CloseAllVersions = closeAllVersions,
                PlaceIds = placeIds,
                UniverseId = universeId
            });
    }

    /// <summary>
    /// Updates a universe
    /// </summary>
    /// <param name="universe">An instance of <see cref="RobloxUniverse"/></param>
    /// <returns>A updated instance of <see cref="RobloxUniverse"/></returns>
    /// <exception cref="RobloxApiException">Error that occures because of invalid API request</exception>
    public async Task<RobloxUniverse> UpdateUniverse( RobloxUniverse universe)
    {
        if (universe.UniverseId == 0)
            throw new RobloxApiException("Universe ID must be provided");

        return (await _client.ThrowIfNull().SendRequest(new UpdateUniverseRequest()
        {
            UniverseId = universe.UniverseId,
            DisplayName = universe.DisplayName,
            Description = universe.Description,
            User = universe.User,
            Group = universe.Group,
            Visibility = universe.Visibility,
            FacebookSocialLink = universe.FacebookSocialLink,
            TwitterSocialLink = universe.TwitterSocialLink,
            YoutubeSocialLink = universe.YoutubeSocialLink,
            TwitchSocialLink = universe.TwitchSocialLink,
            DiscordSocialLink = universe.DiscordSocialLink,
            GuildedSocialLink = universe.GuildedSocialLink,
            RobloxGroupSocialLink = universe.RobloxGroupSocialLink,
            AgeRating = universe.AgeRating,
            ConsoleEnabled = universe.ConsoleEnabled,
            DesktopEnabled = universe.DesktopEnabled,
            MobileEnabled = universe.MobileEnabled,
            TabletEnabled = universe.TabletEnabled,
            VoiceChatEnabled = universe.VoiceChatEnabled,
            VrEnabled = universe.VrEnabled,
            PrivateServerPriceRobux = universe.PrivateServerPriceRobux,
            TemplateRootPlace = universe.RootPlace
        }))!;
    }
    
}