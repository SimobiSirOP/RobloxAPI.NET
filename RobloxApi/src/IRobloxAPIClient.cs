using JetBrains.Annotations;
using RobloxCloudApi.APIRequests.Abstractions;

namespace RobloxCloudApi;

[PublicAPI]
public interface IRobloxApiClient
{
    // Api's
    DataStoresApi DataStores { get; }

    UsersApi Users { get; }

    UniverseApi Universe { get; }

    LuauExecutionApi LuauExecution { get; }

    BadgesApi Badges { get; }

    ThumbnailApi Thumbnails { get; }
    Task<TResponse?> SendRequest<TResponse>(IRequest<TResponse> request);
}