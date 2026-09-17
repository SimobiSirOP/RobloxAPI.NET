using RobloxCloudApi;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;
using RobloxCloudApi.ErrorHandling.Exceptions;

namespace UnitTests.Complete.DataStoresTest;

[Category("Complete")]
[TestFixture]
public class DataStoreTest
{
    private readonly string _dataStoreName = "TestDataStore";
    private readonly string _dataStoreEntry = "TestDataEntry";
    private readonly long[] _dataStoreUsers = new  long[] { 1,  597256084};
    
    [Test]
    [Order(0)]
    public async Task CreateNewDataStore()
    {
        await Globals.Client.DataStores.CreateDataStore(Globals.TestUniverseId, _dataStoreName); // Creation
        var dataStoresList = await Globals.Client.DataStores.GetAllDataStores(Globals.TestUniverseId, null, 10, true);
       
        if (dataStoresList == null) Assert.Fail("No data store returned");
        
        var isDone = dataStoresList.Any(x => x.Id == _dataStoreName && x.State == DataStoreState.ACTIVE);
        Assert.That(isDone, Is.True);
        Assert.Pass();
    }
    
    [Test]
    [Order(1)]
    public async Task AddNewValueToDataStore()
    {
        const string dataStoreValue = "TestValue";
        var result = await Globals.Client.DataStores.CreateDataStoreEntry(
            Globals.TestUniverseId, _dataStoreName, _dataStoreEntry, dataStoreValue, _dataStoreUsers);
        
        
        Assert.That(result.Id, Is.EqualTo(_dataStoreEntry), "Id doesn't match");
        Assert.That(result.Value.ToString(), Is.EqualTo(dataStoreValue), "Values doesn't match");
        Assert.That(result.State, Is.EqualTo(DataStoreState.ACTIVE), "State doesn't match");
        Assert.Pass("Result: " + result.Value.ToString());
    }
    
    [Test]
    [Order(2)]
    public async Task UpdateValueDataStore()
    {
        const int dataStoreValue = 0;
        var result = await Globals.Client.DataStores.UpdateDataStoreEntry(
            Globals.TestUniverseId, _dataStoreName, _dataStoreEntry, dataStoreValue, _dataStoreUsers);
        
        
        Assert.That(result.Id, Is.EqualTo(_dataStoreEntry));
        Assert.That(result.Value!.ToString(), Is.EqualTo("0"));
        Assert.That(result.State, Is.EqualTo(DataStoreState.ACTIVE));
        Assert.Pass();
    }
    
    [Test]
    [Order(3)]
    public async Task IncrementDataStore()
    {
        var result = await Globals.Client.DataStores.IncrementDataStoreEntry(
            Globals.TestUniverseId, _dataStoreName, _dataStoreEntry, 5, _dataStoreUsers);
        
        
        Assert.That(result.Id, Is.EqualTo(_dataStoreEntry));
        Assert.That(result.Value!.ToString(), Is.EqualTo(5.ToString()));
        Assert.That(result.State, Is.EqualTo(DataStoreState.ACTIVE));
        Assert.Pass();
    }
    
    [Test]
    [Order(4)]
    public async Task DeleteDataStoreEntry()
    {

        await Globals.Client.DataStores.GetDataStoreEntry(Globals.TestUniverseId, _dataStoreName,  _dataStoreEntry);
        await Globals.Client.DataStores.DeleteDataStoreEntry(Globals.TestUniverseId, _dataStoreName, _dataStoreEntry);
        
        Assert.ThrowsAsync(typeof(RobloxApiException), async () => await Globals.Client.DataStores.GetDataStoreEntry(Globals.TestUniverseId, _dataStoreName, _dataStoreEntry));
        Assert.Pass();
    }
    
    [Test]
    [Order(5)]
    public async Task DeleteDataStore()
    {
        var result = await Globals.Client.DataStores.DeleteDataStore(Globals.TestUniverseId, _dataStoreName);
        
        Assert.That(result.Id, Is.EqualTo(_dataStoreName));
        Assert.That(result.State, Is.EqualTo(DataStoreState.DELETED));
        Assert.Pass("New State: " + result.State.ToString());
    }
}