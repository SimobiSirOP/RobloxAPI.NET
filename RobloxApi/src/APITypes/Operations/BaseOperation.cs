using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi.APITypes.Operations;

public abstract class BaseOperation : ApiBaseData, IOperation
{
    public static OperationOptions OperationOptions { private get; set; } = new(TimeSpan.FromSeconds(5), 5);
    public abstract bool IsCompleted();

    public async Task<T> WaitForCompletionAsync<T>(IRobloxApiClient client,
        string domain = "https://apis.roblox.com/cloud/v2") where T : class, IOperation
    // Operations are only used in v2 Cloud API as far as I know
    {
        if (IsCompleted()) return (this as T)!;

        // Preparing operation request
        if (!domain.EndsWith("/")) domain += "/";

        string operationPath;
        if (RequestPath != null && RequestPath.StartsWith(domain))
            operationPath = RequestPath;
        else operationPath = domain + RequestPath;

        var operationRequest = new OperationRequest<T>(operationPath);

        for (var attempt = 0; attempt < OperationOptions.NumberOfAttemptsBeforeFailing; attempt++)
        {
            T? result = null;
            result = await client.ThrowIfNull().SendRequest(operationRequest);
            if (result.IsCompleted())
                return result!;
            await Task.Delay(OperationOptions.TimeBetweenAttempts);
        }

        return null!;
    }
}