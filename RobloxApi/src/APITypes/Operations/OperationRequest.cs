using RobloxCloudApi.APIRequests.Abstractions;

namespace RobloxCloudApi.APITypes.Operations;

internal class OperationRequest<T>(string path)
    : RequestBase<T> where T : IOperation
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    public override string RequestPath { get; } = path;
}