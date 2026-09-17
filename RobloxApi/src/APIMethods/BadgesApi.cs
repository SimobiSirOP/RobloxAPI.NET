using RobloxCloudApi.APIRequests.Badges;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.Badges;
using RobloxCloudApi.APITypes.TypeBases;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

public class BadgesApi
{
    private readonly IRobloxApiClient _client;

    public BadgesApi(IRobloxApiClient client)
    {
        this._client = client;
    }
    
    #region Badges
    
    public async Task<OldListResponseBase<RobloxBadge>> GetBadgesFromUniverse(
        long universeId,
        string? cursor = null,
        int maxPageSize = 10,
        GetBadgesFromUniverseRequest.BadgesSortOrder sortOrder = GetBadgesFromUniverseRequest.BadgesSortOrder.Rank)
    {
        return (await _client.ThrowIfNull().SendRequest(new GetBadgesFromUniverseRequest()
        {
            Cursor = cursor,
            MaxPageSize = maxPageSize,
            SortOrder = sortOrder,
            UniverseId = universeId
        }))!;
    }
    
    public async Task<OldListResponseBase<RobloxBadgeIcon>> GetMultipleBadgeIcons(
        long[] badgeIds,
        bool isCurcular = true,
        RobloxThumbnailFormat format = RobloxThumbnailFormat.PNG)
    {
        return (await _client.ThrowIfNull().SendRequest(new GetMultipleBadgeIconsRequest()
        {
            BadgeIds = badgeIds,
            IsCircular = isCurcular,
            Format = format
        }))!;
    }

    public async Task<RobloxBadge> GetBadge(
        long badgeId)
    {
        return (await _client.ThrowIfNull().SendRequest(new GetBadgeInformationRequest()
        {
            BadgeId = badgeId
        }))!;
    }
    
    public async Task<object> UpdateBadgeLocalizationIcon(
        long badgeId,
        string languageCode,
        byte[] icon)
    {
        return (await _client.ThrowIfNull().SendRequest(new UpdateBadgeLocalizedIconRequest()
        {
            BadgeId = badgeId,
            LanguageCode = languageCode,
            Icon = icon
        }))!;
    }
    
    public async Task<object> UpdateBadgeLocalizationDescription(
        long badgeId,
        string languageCode,
        string description)
    {
        return (await _client.ThrowIfNull().SendRequest(new UpdateBadgeLocalizedDescriptionRequest()
        {
            BadgeId = badgeId,
            LanguageCode = languageCode,
            Description = description
        }))!;
    }
    
    public async Task<object> UpdateBadgeLocalizationName(
        long badgeId,
        string languageCode,
        string name)
    {
        return (await _client.ThrowIfNull().SendRequest(new UpdateBadgeLocalizedNameRequest()
        {
            BadgeId = badgeId,
            LanguageCode = languageCode,
           Name = name
        }))!;
    }
    
    public async Task<object> UpdateBadgeLocalizationNameAndDesc(
        long badgeId,
        string languageCode,
        string name,
        string description)
    {
        return (await _client.ThrowIfNull().SendRequest(new UpdateBadgeLocalizedNameAndDescriptionRequest()
        {
            BadgeId = badgeId,
            LanguageCode = languageCode,
            Name = name,
            Description = description
        }))!;
    }
    
    #endregion
}