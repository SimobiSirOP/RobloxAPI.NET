using RobloxCloudApi;
using RobloxCloudApi.APITypes.AccessTokens;

namespace UnitTests;

public static class Globals
{
    public static IRobloxApiClient Client { get; set; } = null!;
    public static long TestUniverseId { get; set; }
}

[SetUpFixture]
public class GlobalInit
{
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        var botToken = System.Environment.GetEnvironmentVariable("ROBLOX_API_TOKEN");
        Globals.TestUniverseId = long.Parse(System.Environment.GetEnvironmentVariable("ROBLOX_UNIVERSE_ID")!);
        Globals.Client = new RobloxApiClient(new RobloxApiClientSettings(new ApiKeyToken(botToken), TimeSpan.FromSeconds(20), 7));

    }
}