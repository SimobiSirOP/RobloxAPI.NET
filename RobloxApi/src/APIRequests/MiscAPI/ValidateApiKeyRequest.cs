using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.AuthenticationTypes;

namespace RobloxCloudApi.APIRequests.MiscAPI;

// No auth
internal class ValidateApiTokenRequest : RequestBase<ApiKeyInfo>
{
    [JsonIgnore] public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    [JsonIgnore] public override string RequestPath { get; } = "https://apis.roblox.com/api-keys/v1/introspect";

    [JsonPropertyName("apiKey")] public string ApiKey { get; set; }
}