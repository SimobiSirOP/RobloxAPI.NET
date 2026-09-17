namespace RobloxCloudApi.APITypes.AccessTokens;

public class ApiKeyToken : IAccessToken
{
    public string ApiKey { get; set; }
    public HttpRequestMessage ApplyToRequest(HttpRequestMessage request)
    {
        request.Headers.Add("x-api-key", $"{ApiKey}");
        return request;
    }
    
    public ApiKeyToken(string apiKey)
    {
        ApiKey = apiKey;
    }
}