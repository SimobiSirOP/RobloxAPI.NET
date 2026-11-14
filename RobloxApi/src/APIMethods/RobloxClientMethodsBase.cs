namespace RobloxCloudApi;

public abstract class RobloxClientMethodsBase
{
    protected RobloxClientMethodsBase(IRobloxApiClient client)
    {
        _client = client;
    }

    protected IRobloxApiClient _client { get; }
}