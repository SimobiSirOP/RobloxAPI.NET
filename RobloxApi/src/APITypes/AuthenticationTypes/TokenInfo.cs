using System.Text.Json.Serialization;

namespace RobloxCloudApi.APITypes.AuthenticationTypes;

public class TokenInfo
{
    [JsonPropertyName("active")]
    public bool Active { get; set; }
    
    [JsonPropertyName("jti")]
    public string Jti { get; set; }
    
    [JsonPropertyName("iss")]
    public string Iss { get; set; }
    
    [JsonPropertyName("token_type")]
    public OAuthTokenTypeEnum TokenType { get; set; }
    
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }
    
    [JsonPropertyName("aud")]
    public string Aud { get; set; }
    
    [JsonPropertyName("sub")]
    public string Sub { get; set; }
    
    [JsonPropertyName("scope")]
    public string Scope { get; set; }
    
    [JsonPropertyName("exp")]
    public long Exp { get; set; }
    
    [JsonPropertyName("iat")]
    public long Iat { get; set; }
}

public enum OAuthTokenTypeEnum
{
    Bearer
    // I fill figure out other tokenTypes later, fell free to add them
}