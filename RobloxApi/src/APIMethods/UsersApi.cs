using RobloxCloudApi.APIRequests.UsersApi;
using RobloxCloudApi.APIRequests.UsersApi.Restrictions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.APITypes.RobloxGeneralTypes;
using RobloxCloudApi.APITypes.RobloxObjects.Users;
using RobloxCloudApi.APITypes.TypeBases;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

public class UsersApi
{
    private readonly IRobloxApiClient _client;

    public UsersApi(IRobloxApiClient client)
    {
        this._client = client;
    }
    
    
    /// <summary>
    ///     Use this method to get a list of RobloxUsers from a list of Usernames
    /// </summary>
    /// <param name="usernames">An array of roblox user usernames</param>
    /// <param name="excludeBannedUsers">Should it include banned users in search or not</param>
    /// <returns>An array of <see cref="RobloxUser" /></returns>
    public async Task<OldListResponseBase<RobloxUser>> GetUsersFromUsernames(
        
        string[] usernames,
        bool excludeBannedUsers = true
    )
    {
        return (await _client.ThrowIfNull().SendRequest(new GetUsersFromUsernamesRequest
        {
            Usernames = usernames,
            ExcludeBannedUsers = excludeBannedUsers
        }))!;
    }

    /// <summary>
    ///     Use this method to get a user from Roblox username
    /// </summary>
    /// <param name="username">A Roblox user Username</param>
    /// <returns>A instance of <see cref="RobloxUser" /></returns>
    public async Task<RobloxUser?> GetUserFromUsername(
        string username)
    {
        var robloxUsers = (await this.GetUsersFromUsernames([username])).List;
        if (robloxUsers!.Length == 0)
            return null;
        // Validating, because it also checks for previous usernames
        foreach (var robloxUser in robloxUsers)
            if (robloxUser.Username!.ToLower() == username.ToLower())
                return robloxUser;
        return null;
    }

    /// <summary>
    ///     Use this method to get a Roblox Users from array of userIds
    /// </summary>
    /// <param name="userIds">An array of Roblox user IDs</param>
    /// <param name="excludeBannedUsers">Should it include banned users in search or not</param>
    /// <returns>An array of <see cref="RobloxUser" /></returns>
    public async Task<RobloxUser[]> GetUsersFromIds(
        
        long[] userIds,
        bool excludeBannedUsers = true)
    {
        return (await _client.ThrowIfNull().SendRequest(new GetUsersFromIdsRequest
        {
            UserIds = userIds,
            ExcludeBannedUsers = excludeBannedUsers
        }))!;
    }

    /// <summary>
    ///     Use this method to get full info of a User
    /// </summary>
    /// <param name="userId">A Roblox user id</param>
    /// <returns>An instance of <see cref="RobloxFullUser" /></returns>
    public async Task<RobloxFullUser> GetFullUserFromId(
        
        long userId)
    {
        return (await _client.ThrowIfNull().SendRequest(new GetUserFromIdRequest
        {
            UserId = userId
        }))!;
    }

    public async Task<RobloxOperation> GenerateUserThumbnail(
        
        long userId,
        RobloxThumbnailSize size = RobloxThumbnailSize.Size420,
        RobloxThumbnailFormat format = RobloxThumbnailFormat.PNG,
        RobloxThumbnailShape shape = RobloxThumbnailShape.ROUND,
        bool shouldWait = true)
    {
        var uncompletedOperation = (await _client.ThrowIfNull().SendRequest(new GenerateUserThumbnailRequest
        {
            UserId = userId,
            Size = size,
            Format = format,
            Shape = shape
        }))!;
        if (shouldWait)
            return await uncompletedOperation.WaitForCompletionAsync<RobloxOperation>(_client)!;
        else 
            return uncompletedOperation;
    }
    
    
    
     /// <summary>
    ///     Use this method to get one page of Restrictions
    /// </summary>
    /// <param name="universeId">A roblox universe id</param>
    /// <param name="maxPageSize">
    ///     Maximum size of a page, see
    ///     <see href="https://create.roblox.com/docs/cloud/reference/features/users#Cloud_ListUserRestrictions" />
    /// </param>
    /// <param name="pageToken">
    ///     A page token, can be null. see
    ///     <see href="https://create.roblox.com/docs/cloud/reference/features/users#Cloud_ListUserRestrictions" />
    /// </param>
    /// <returns>The array of <see cref="RestrictionList" /></returns>
    public async Task<RestrictionList> ListRestrictedUsersInUniverse(
        
        long universeId,
        int maxPageSize = 10,
        string pageToken = null!)
    {
        var result = (await _client.ThrowIfNull().SendRequest(new ListUserRestrictionsRequest
        {
            UniverseId = universeId,
            MaxPageSize = maxPageSize,
            PageToken = pageToken
        }))!;
        return result;
    }

    /// <summary>
    ///     Use this method to get specific player restrictions
    /// </summary>
    /// <param name="userId">A Roblox user id</param>
    /// <param name="universeId">A roblox universe id</param>
    /// <returns>A instance of <see cref="RestrictionData" /></returns>
    public async Task<RestrictionData> GetUserRestrictionsInUniverse(
        
        long userId,
        long universeId
    )
    {
        return (await _client.ThrowIfNull().SendRequest(new GetUserRestrictionsRequest
        {
            UniverseId = universeId,
            UserId = userId
        }))!;
    }

    /// <summary>
    ///     Use this method to change User restriction
    /// </summary>
    /// <param name="userId">A roblox player ID</param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="active">Is restriction active</param>
    /// <param name="startTime">Start time of a restriction</param>
    /// <param name="duration">Duration of a restriction</param>
    /// <param name="displayReason">Public reason of a restriction</param>
    /// <param name="privateReason">Reason that only developers can see</param>
    /// <param name="excludeAlts">Should this restriction also apply to alt accounts</param>
    /// <param name="inherited">Should this restriction be inherited by other users</param>
    /// <returns>An Instance of <see cref="RestrictionData" /></returns>
    public async Task<RestrictionData> SetUserRestrictionsInUniverse(
        
        long userId,
        long universeId,
        bool active,
        DateTime startTime,
        string? duration,
        string displayReason,
        string privateReason,
        bool? excludeAlts = false,
        bool? inherited = true)
    {
        var restriction = new GameJoinRestriction
        {
            Active = active,
            StartTime = startTime,
            Duration = duration,
            DisplayReason = displayReason,
            PrivateReason = privateReason,
            ExcludeAltAccounts = excludeAlts,
            Inherited = inherited
        };
        return (await _client.ThrowIfNull().SendRequest(new UpdateRestrictionRequest()
        {
            GameJoinRestriction = restriction,
            UniverseId = universeId,
            UserId = userId
        }))!;
    }

    /// <summary>
    ///     Use this method to ban specific player from roblox universe
    /// </summary>
    /// <param name="userId">A Roblox user ID</param>
    /// <param name="universeId">A Roblox universe ID</param>
    /// <param name="duration">Duration of a ban in seconds</param>
    /// <param name="displayReason">Public reason of a ban</param>
    /// <param name="privateReason">A reason only for developers to see</param>
    /// <param name="excludeAlts">Should it ban alt accounts too or not</param>
    /// <returns>An Instance of <see cref="RestrictionData" /></returns>
    public async Task<RestrictionData> BanUserFromUniverse(
        
        long userId,
        long universeId,
        long? duration = null,
        string displayReason = "You have been banned!",
        string? privateReason = null,
        bool? excludeAlts = false)
    {
        return await this.SetUserRestrictionsInUniverse(userId, universeId, true, DateTime.UtcNow, duration != null ? duration + "s" : null,
            displayReason, privateReason ?? displayReason, excludeAlts);
    }

    /// <summary>
    ///     Use this method to unban specific player of roblox universe
    /// </summary>
    /// <param name="userId">A Roblox user ID</param>
    /// <param name="universeId">A Roblox universe ID</param>
    /// <returns>An Instance of <see cref="RestrictionData" /></returns>
    public async Task<RestrictionData> UnbanUserFromUniverse(
        
        long userId,
        long universeId)
    {
        return await this.SetUserRestrictionsInUniverse(userId, universeId, false, DateTime.UtcNow, null, string.Empty,
            string.Empty, null);
    }
}