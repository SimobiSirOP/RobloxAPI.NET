namespace RobloxCloudApi.APITypes.AccessTokens;

public class UserCookie : IAccessToken
{
    
    public string Cookie { get; }
    
    public HttpRequestMessage ApplyToRequest(HttpRequestMessage request)
    {
        request.Headers.TryAddWithoutValidation("Cookie", $".ROBLOSECURITY={Cookie};");
        return request;
    }
    
    public UserCookie(string cookie)
    {
        Cookie = cookie;
    }
}