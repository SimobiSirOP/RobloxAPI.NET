using System.Text.Json.Serialization;

namespace RobloxCloudApi.APITypes.AuthenticationTypes;

public class TokenExchangeResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
    
    [JsonPropertyName("expires_in")]
    public long ExpiresIn { get; set; }
    
    [JsonPropertyName("token_type")]
    public OAuthTokenTypeEnum TokenType { get; set; }
    
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }
}