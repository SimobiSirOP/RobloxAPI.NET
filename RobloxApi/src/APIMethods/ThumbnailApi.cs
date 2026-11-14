using RobloxCloudApi.APIRequests.UsersApi;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.APITypes.RobloxObjects.Thumbnails;
using RobloxCloudApi.APITypes.TypeBases;
using RobloxCloudApi.ErrorHandling.Exceptions;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

public class ThumbnailApi : RobloxClientMethodsBase
{
    public ThumbnailApi(IRobloxApiClient client) : base(client)
    {
    }


    /// <summary>
    ///     Generate a thumbnail for a user
    /// </summary>
    /// <param name="userId">A Roblox user id</param>
    /// <param name="size">A image size <see cref="RobloxThumbnailSize"> </param>
    /// <param name="format">A JPG or PNG format of generated image</param>
    /// <param name="shape">A Round of Square shape of a image</param>
    /// <param name="shouldWait">Should this operation automatically wait for its end</param>
    /// <returns></returns>
    public async Task<ThumbnailOperation> GenerateUserThumbnail(
        long userId,
        RobloxThumbnailSize size = RobloxThumbnailSize.Size420,
        RobloxThumbnailFormat format = RobloxThumbnailFormat.PNG,
        RobloxThumbnailShape shape = RobloxThumbnailShape.ROUND,
        bool shouldWait = true)
    {
        if (format == RobloxThumbnailFormat.WEBP) throw new RobloxApiException("WebP format is not supported.");
        var uncompletedOperation = (await _client.ThrowIfNull().SendRequest(new GenerateUserThumbnailRequest
        {
            UserId = userId,
            Size = size,
            Format = format,
            Shape = shape
        }))!;
        if (shouldWait)
            return await uncompletedOperation.WaitForCompletionAsync<ThumbnailOperation>(_client)!;
        return uncompletedOperation;
    }

    /// <summary>
    ///     Generate a full-body avatar thumbnail for a list of users
    /// </summary>
    /// <param name="userIds">An array of userIds</param>
    /// <param name="size">
    ///     Size specified in
    ///     <see href="https://create.roblox.com/docs/cloud/reference/features/thumbnails#thumbnails_get_v1_users_avatar" />
    /// </param>
    /// <param name="format">A future format of generated thumbnails</param>
    /// <param name="includeBackground">Specifies the existence of the generated thumbnails' background</param>
    /// <param name="isCircular">Specifies if the generated thumbnails should be circular</param>
    /// <returns>A v1 api list of <see cref="ThumbnailImageData" /></returns>
    public async Task<OldListResponseBase<ThumbnailImageData>> GenerateFullBodyThumbnail(
        long[] userIds,
        RobloxFullBodyThumbnailSize size = RobloxFullBodyThumbnailSize.Size150x150,
        RobloxThumbnailFormat format = RobloxThumbnailFormat.PNG,
        bool includeBackground = false,
        bool isCircular = false)
    {
        return (await _client.ThrowIfNull().SendRequest(new GenerateFullBodyThumbnailRequest
            {
                UserIds = userIds,
                Size = size,
                Format = format,
                IncludeBackground = includeBackground,
                IsCircular = true
            }
        ))!;
    }

    /// <summary>
    ///     Generate a full-body avatar thumbnail for a specific user
    /// </summary>
    /// <param name="userId">A user id</param>
    /// <param name="size">
    ///     Size specified in
    ///     <see href="https://create.roblox.com/docs/cloud/reference/features/thumbnails#thumbnails_get_v1_users_avatar" />
    /// </param>
    /// <param name="format">A future format of generated thumbnail</param>
    /// <param name="includeBackground">Specifies the existence of the generated thumbnail's background</param>
    /// <param name="isCircular">Specifies if the generated thumbnail should be circular</param>
    /// <returns>A <see cref="ThumbnailImageData" /></returns>
    public async Task<ThumbnailImageData?> GenerateFullBodyThumbnail(long userId,
        RobloxFullBodyThumbnailSize size = RobloxFullBodyThumbnailSize.Size150x150,
        RobloxThumbnailFormat format = RobloxThumbnailFormat.PNG,
        bool includeBackground = false,
        bool isCircular = false)
    {
        return (await GenerateFullBodyThumbnail(new[] { userId }, size, format, includeBackground, isCircular))?.List
            ?.FirstOrDefault();
    }

    /// <summary>
    ///     Generates thumbnails for a list of assets
    /// </summary>
    /// <param name="assetIds">A list of asset ids</param>
    /// <param name="size">A size of an assets</param>
    /// <param name="returnPolicy">A specified option that specifies generation of thumbnail</param>
    /// <param name="format">Format of specified thumbnails</param>
    /// <param name="isCircular">Specifies if generated thumbnails should be circular</param>
    /// <returns>A v1 list of <see cref="ThumbnailImageData" /></returns>
    public async Task<OldListResponseBase<ThumbnailImageData>> GenerateAssetsThumbnail(
        long[] assetIds,
        RobloxAssetsV1ThumbnailSize size = RobloxAssetsV1ThumbnailSize.Size250x250,
        RobloxThumbnailReturnPolicy returnPolicy = RobloxThumbnailReturnPolicy.PlaceHolder,
        RobloxThumbnailFormat format = RobloxThumbnailFormat.PNG,
        bool isCircular = false)
    {
        return (await _client.SendRequest(new GenerateAssetsThumbnailRequests
        {
            AssetIds = assetIds,
            IsCircular = isCircular,
            Format = format,
            ReturnPolicy = returnPolicy,
            Size = size
        }))!;
    }

    /// <summary>
    ///     Generates a thumbnail for an asset
    /// </summary>
    /// <param name="assetId">An asset id</param>
    /// <param name="size">A size of a future thumbnail</param>
    /// <param name="returnPolicy">A specified option that specifies generation of a thumbnail</param>
    /// <param name="format">Format of a thumbnail</param>
    /// <param name="isCircular">Specifies if a generated thumbnail should be circular</param>
    /// <returns>A <see cref="ThumbnailImageData" /></returns>
    public async Task<ThumbnailImageData?> GenerateAssetsThumbnail(long assetId,
        RobloxAssetsV1ThumbnailSize size = RobloxAssetsV1ThumbnailSize.Size250x250,
        RobloxThumbnailReturnPolicy returnPolicy = RobloxThumbnailReturnPolicy.PlaceHolder,
        RobloxThumbnailFormat format = RobloxThumbnailFormat.PNG,
        bool isCircular = false)
    {
        return (await GenerateAssetsThumbnail([assetId], size, returnPolicy, format, isCircular))?.List
            ?.FirstOrDefault();
    }
}