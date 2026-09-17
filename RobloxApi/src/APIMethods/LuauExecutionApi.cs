using RobloxCloudApi.APIRequests.Badges;
using RobloxCloudApi.APIRequests.LuauExecution;
using RobloxCloudApi.APIRequests.UniverseData.PlacesApi;
using RobloxCloudApi.APIRequests.UniverseData.UniverseApi;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.APITypes.RobloxGeneralTypes;
using RobloxCloudApi.APITypes.RobloxObjects.Badges;
using RobloxCloudApi.APITypes.RobloxObjects.Universe;
using RobloxCloudApi.APITypes.TypeBases;
using RobloxCloudApi.ErrorHandling.Exceptions;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

public class LuauExecutionApi
{
    private readonly IRobloxApiClient _client;

    public LuauExecutionApi(IRobloxApiClient client)
    {
        this._client = client;
    }
    
    /// <summary>
    /// Executes a Luau script in a specific place within a Roblox universe.
    /// </summary>
    /// <param name="universeId">The ID of the Roblox universe</param>
    /// <param name="placeId">The ID of the place within the universe</param>
    /// <param name="script">The Luau script to execute. This should be null if binary input is provided.</param>
    /// <param name="timeout">The timeout duration for the script execution process.</param>
    /// <param name="returnErrorsInstead">Indicates whether to return errors instead of throwing exceptions.</param>
    /// <param name="enableBinaryOutput">Specifies whether the execution should produce binary output.</param>
    /// <param name="binaryInput">Optional binary input for the execution in place of a script.</param>
    /// <returns>An instance of <see cref="LuauExecutionOperation"/></returns>
    public async Task<LuauExecutionOperation> RunLuauExecution(
        long universeId,
        long placeId,
        string? script,
        RobloxDuration timeout,
        bool returnErrorsInstead = false,
        bool enableBinaryOutput = false,
        RobloxBinary? binaryInput = null,
        bool shouldWait = true)
    {
        var output = new object();
        object? error = null;
        if (returnErrorsInstead)
        {
            output = null;
            error = new object();
        }

        var uncompletedOperation = await _client.ThrowIfNull().SendRequest(
            new CreateLuauExecutionRequest
            {
                UniverseId = universeId,
                PlaceId = placeId,
                Timeout = timeout,
                Script = script,
                Output = output,
                Error = error,
                BinaryInput = binaryInput,
                EnableBinaryOutput = enableBinaryOutput
            })!;
        
        if (shouldWait)
            return await uncompletedOperation!.WaitForCompletionAsync<LuauExecutionOperation>(_client)!;
        else 
            return uncompletedOperation!;
    }

    /// <summary>
    /// Retrieves a list of Luau execution logs for a specific operation in a Roblox Universe.
    /// </summary>
    /// <param name="operation">The Luau execution operation</param>
    /// <param name="pageToken">An optional token to fetch a specific page of logs. Can be null to fetch the first page.</param>
    /// <param name="maxPageSize">The maximum number of log entries to include in a single page.</param>
    /// <param name="view">The view format of logs (e.g., flat or structured).</param>
    /// <returns>An instance of <see cref="LuauExecutionLogList" /></returns>
    public async Task<LuauExecutionLogList> GetLuauExecutionLog(
        LuauExecutionOperation operation,
        string? pageToken = null,
        int maxPageSize = 10,
        LuauLogView view = LuauLogView.FLAT
    )
    {
        const string domain = "https://apis.roblox.com/cloud/v2/";

        var requestUrl = domain + operation.RequestPath;

        var request = new GetLuauExecutionLogsRequest(requestUrl)
        {
            MaxPageSize = maxPageSize,
            PageToken = pageToken,
            View = view
        };
        return (await _client.ThrowIfNull().SendRequest(request))!;
    }
    
}