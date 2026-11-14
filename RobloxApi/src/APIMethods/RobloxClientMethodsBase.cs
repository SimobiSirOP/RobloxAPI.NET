namespace RobloxCloudApi;

public abstract class RobloxClientMethodsBase
{
    protected IRobloxApiClient _client { get; }

    protected RobloxClientMethodsBase(IRobloxApiClient client)
    {
        this._client = client;
    }
}