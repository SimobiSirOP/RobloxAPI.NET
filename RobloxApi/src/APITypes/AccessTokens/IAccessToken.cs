using System.Diagnostics.Contracts;

namespace RobloxCloudApi.APITypes.AccessTokens;

public interface IAccessToken
{
    [Pure]
    public HttpRequestMessage ApplyToRequest(HttpRequestMessage request);
}