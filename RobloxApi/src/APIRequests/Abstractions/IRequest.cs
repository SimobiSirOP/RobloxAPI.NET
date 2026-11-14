using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace RobloxCloudApi.APIRequests.Abstractions;

public interface IRequest
{
    [JsonIgnore] public HttpMethod HttpMethod { get; }

    [UriString] [JsonIgnore] public string RequestPath { get; }

    public HttpContent? GetHttpContent();

    public string GetRequestUri();
}

public interface IRequest<TResponse> : IRequest;