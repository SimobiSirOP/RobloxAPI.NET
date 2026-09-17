using RobloxCloudApi;

namespace UnitTests.Complete.UniverseRequestsTesting;

[Category("Complete")]
[TestFixture]
public class UniverseManipulationTest
{
    [Test]
    [Order(1)]
    public async Task TestUniverseGetAndUpdate()
    {
        var Universe = await Globals.Client.Universe.GetUniverse(Globals.TestUniverseId);
        if (Universe == null) Assert.Fail("Universe is null");
        if (Universe.UniverseId == 0) Assert.Fail("Universe Id is not specified");
        if (Universe.UniverseId != Globals.TestUniverseId) Assert.Fail("Universe Id is not correct");

        var universeDesktopEnabled = Universe.DesktopEnabled;
        Universe.DesktopEnabled = !Universe.DesktopEnabled;
        var updatedUniverse = await Globals.Client.Universe.UpdateUniverse(Universe);
        if (updatedUniverse == null) Assert.Fail("Updated Universe is null");
        if (updatedUniverse.DesktopEnabled == universeDesktopEnabled) Assert.Fail("Universe DesktopEnabled is not updated");
        
        Assert.Pass();
    }
    
    [Test]
    [Order(2)]
    public async Task TestUniverseMessage()
    {
        var message = "Test Message";
        var topic = "Test Topic";
        await Globals.Client.Universe.PublishUniverseMessage(Globals.TestUniverseId, message, topic);
        Assert.Pass();
    }

    [Test]
    [Order(3)]
    public async Task TestUniverseServersRestart()
    {
        await Globals.Client.Universe.RestartUniverseServers(Globals.TestUniverseId);
        Assert.Pass();
    }
    
}