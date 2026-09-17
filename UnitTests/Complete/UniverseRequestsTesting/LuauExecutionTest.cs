using JetBrains.Annotations;
using RobloxCloudApi;
using RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.APITypes.RobloxGeneralTypes;
using RobloxCloudApi.APITypes.RobloxObjects.Universe;
using RobloxCloudApi.Helpers;

namespace UnitTests.Complete.UniverseRequestsTesting;

[Category("Basic")]
[Category("Complete")]
[TestFixture]
public class LuauExecutionTest
{
    //[LanguageInjection("Lua")]
    public static string Script = """

                 local test = {}
                  test.meow = "meow"
                 test.wthImDoin = 100
                 
                 return test;
                 """;
    
    
    [Test]
    [Order(0)]
    public async Task TestLuauExecution()
    {
        var placeIdList = await Globals.Client.Universe.GetUniversePlaces(Globals.TestUniverseId);
        long testingPlaceId = placeIdList.List!.First().Id!.Value;

        
        
        var operation = await Globals.Client.LuauExecution.RunLuauExecution(
            Globals.TestUniverseId, 
            testingPlaceId,
            Script,
            new RobloxDuration(5),
            true);
        
        Assert.That(operation, Is.Not.Null);
        Assert.That(operation.State, Is.EqualTo(LuauExecutionState.COMPLETE), operation.GetErrorString());
        Assert.Pass("Result operation: " + Serializer.SerializeToString(operation));
    }
}