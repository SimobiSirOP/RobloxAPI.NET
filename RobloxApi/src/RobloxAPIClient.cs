using System.Net;
using JetBrains.Annotations;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.AccessTokens;
using RobloxCloudApi.APITypes.TypeBases;
using RobloxCloudApi.ErrorHandling;
using RobloxCloudApi.ErrorHandling.Exceptions;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

[PublicAPI]
public class RobloxApiClient : IRobloxApiClient
{
    //
    public DataStoresApi DataStores { get; }

    public UsersApi Users { get; }
    
    public UniverseApi Universe { get; }
    
    public LuauExecutionApi LuauExecution { get; }
    
    public BadgesApi Badges { get; }
    //
    private readonly HttpClient _httpClient;

    public RobloxApiClient(RobloxApiClientSettings robloxApiClientSettings, HttpClient? httpClient = default)
    {
        _robloxApiClientSettings = robloxApiClientSettings;
        _httpClient = httpClient ??
                      new HttpClient(new SocketsHttpHandler
                          { PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1) });

        DataStores = new DataStoresApi(this);
        Users = new UsersApi(this);
        Universe = new UniverseApi(this);
        LuauExecution = new LuauExecutionApi(this);
        Badges = new BadgesApi(this);
    }

    private RobloxApiClientSettings _robloxApiClientSettings { get; set; }

    private void ProcessAuthentication(Type requestType, HttpRequestMessage request)
    {
        var needsUserCookie = Attribute.IsDefined(requestType, typeof(UserCookieAuth));
        var needsApiToken = Attribute.IsDefined(requestType, typeof(UserCookieAuth));

        if (needsApiToken && _robloxApiClientSettings.Auth.ApiKeyToken != null)
        {
            request = _robloxApiClientSettings.Auth.ApiKeyToken.ApplyToRequest(request);
            return;
        }

        if (needsUserCookie && _robloxApiClientSettings.Auth.UserCookie != null)
        {
            request = _robloxApiClientSettings.Auth.UserCookie.ApplyToRequest(request);
            return;
        }

        // Ignoring NoAuth, coz adding api token can break stuff
        if (Attribute.IsDefined(requestType, typeof(NoAuth))) return;
        
        if (needsApiToken && needsUserCookie)
            throw new InvalidOperationException(
                "This request requires either ApiToken or UserCookie"
            );
        if (needsApiToken)
            throw new InvalidOperationException("This request requires ApiToken");
        if (needsUserCookie)
            throw new InvalidOperationException("This request requires UserCookie");
        
        // if nothing is required, then adding either apiToken or userCookie.
        if (_robloxApiClientSettings.Auth.ApiKeyToken != null)
            request = _robloxApiClientSettings.Auth.ApiKeyToken.ApplyToRequest(request);
        else
        {
            if (_robloxApiClientSettings.Auth.UserCookie != null)
                request = _robloxApiClientSettings.Auth.UserCookie.ApplyToRequest(request);
        }
        
    }
    
    public async Task<TResponse?> SendRequest<TResponse>(IRequest<TResponse> request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        for (var attempts = 0;; attempts++)
        {
            using var httpRequest = new HttpRequestMessage(request.HttpMethod, request.GetRequestUri());
            var requestContent = request.GetHttpContent();
            httpRequest.Content = requestContent;
            ProcessAuthentication(request.GetType(), httpRequest);

            if (requestContent != null)
                await requestContent.LoadIntoBufferAsync().ConfigureAwait(false);

            HttpResponseMessage httpResponseMessage;
            try
            {
                httpResponseMessage = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);
            }
            catch (TaskCanceledException exception)
            {
                throw new TimeoutException("Request timed out: ", exception);
            }
            catch (Exception exception)
            {
                throw new RobloxApiException("Exception occurred during a request to Roblox API:", exception);
            }

            using (httpResponseMessage)
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    if (httpResponseMessage.StatusCode == HttpStatusCode.TooManyRequests &&
                        attempts <= _robloxApiClientSettings.AmountOfRetries)
                    {
                        // Simple help with 404
                        await Task.Delay(_robloxApiClientSettings.Timeout).ConfigureAwait(false);
                        continue;
                    }

                    throw new RobloxApiException(await ErrorParser.GetErrorString(httpResponseMessage));
                }

                return Serializer.SerializeFromString<TResponse>(
                    await httpResponseMessage.Content.ReadAsStringAsync());
            }
        }
    }
    
}

public class RobloxApiClientSettings
{
    // Raw Auth
    public RobloxApiClientSettings(AuthOptions auth, TimeSpan requestTimeout, int requestRetryAmount = 5)
    {
        Auth = auth;
        Timeout = requestTimeout;
        AmountOfRetries = requestRetryAmount;
    }

    public RobloxApiClientSettings(AuthOptions auth, int requestRetryAmount = 5)
    {
        Auth = auth;
        Timeout = new TimeSpan(0, 0, 5);
        AmountOfRetries = requestRetryAmount;
    }
    
    // Api key

    public RobloxApiClientSettings(ApiKeyToken apiKeyToken, TimeSpan requestTimeout, int requestRetryAmount = 5)
    {
        Auth = new AuthOptions(apiKeyToken);
        Timeout = requestTimeout;
        AmountOfRetries = requestRetryAmount;
    }
    
    public RobloxApiClientSettings(ApiKeyToken apiKeyToken, int requestRetryAmount = 5)
    {
        Auth = new AuthOptions(apiKeyToken);
        Timeout = new TimeSpan(0, 0, 5);
        AmountOfRetries = requestRetryAmount;
    }
    
    // User cookie
    
    public RobloxApiClientSettings(UserCookie userCookie, TimeSpan requestTimeout, int requestRetryAmount = 5)
    {
        Auth = new AuthOptions(userCookie);
        Timeout = requestTimeout;
        AmountOfRetries = requestRetryAmount;
    }
    
    public RobloxApiClientSettings(UserCookie userCookie, int requestRetryAmount = 5)
    {
        Auth = new AuthOptions(userCookie);
        Timeout = new TimeSpan(0, 0, 5);
        AmountOfRetries = requestRetryAmount;
    }
    
    public RobloxApiClientSettings(int requestRetryAmount = 5)
    {
        Auth = new AuthOptions();
        Timeout = new TimeSpan(0, 0, 5);
        AmountOfRetries = requestRetryAmount;
    }
    

    public TimeSpan Timeout { get; }

    public int AmountOfRetries { get; }
    
    public AuthOptions Auth { get; }

    public class AuthOptions
    {
        public ApiKeyToken? ApiKeyToken { get; set; }
        
        public UserCookie? UserCookie { get; set; }

        public AuthOptions(ApiKeyToken apiKeyToken)
        {
            ApiKeyToken = apiKeyToken;
        }
        
        public AuthOptions(UserCookie userCookie)
        {
            UserCookie = userCookie;
        }
        
        public AuthOptions()
        {
        }
    }
}
