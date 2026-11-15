using RobloxCloudApi;
using RobloxCloudApi.APITypes.RobloxObjects.Users;
using RobloxCloudApi.Helpers;

namespace UnitTests.Complete.UsersApiTest;

[TestFixture]
[Parallelizable(ParallelScope.All)]
[Category("Users")]
public class ThumbnailTests
{
    private readonly string _testUserName = Globals.TestUserName; // This roblox dev user, won't be changed (you can't ban Roblox, so had to use myself)

    private RobloxUser _testUser;

    private IRobloxApiClient _client => Globals.Client;

    [SetUp]
    public async Task Setup()
    {
        _testUser = await Globals.Client.Users.GetUserFromUsername(_testUserName)!;
        if (_testUser == null)
        {
            Assert.Fail("Test user not found");
        }
    }

    [Test]
    
    public async Task TestUserThumbnail()
    {
        var thumbnail = await _client.Thumbnails.GenerateUserThumbnail(_testUser.UserId);
        if (thumbnail == null)
        {
            Assert.Fail("Thumbnail not found");
        }
        Assert.Pass(Serializer.SerializeToString(thumbnail));
    }
    
    [Test]
    public async Task TestFullBodyThumbnail()
    {
        var thumbnail = await _client.Thumbnails.GenerateFullBodyThumbnail(_testUser.UserId);
        if (thumbnail == null)
        {
            Assert.Fail("Thumbnail not found");
        }
        Assert.Pass(Serializer.SerializeToString(thumbnail));
    }
    
    [Test]
    public async Task TestAssetsThumbnail()
    {
        // Will use place to test
        var places = await _client.Universe.GetUniversePlaces(Globals.TestUniverseId);
        
        long placeId = places.List?.First().Id ?? throw new Exception("No place found");
        
        var thumbnail = await _client.Thumbnails.GenerateAssetsThumbnail(placeId); // Place is an asset, technically
        if (thumbnail == null)
        {
            Assert.Fail("Thumbnail not found");
        }
        Assert.Pass(Serializer.SerializeToString(thumbnail));
    }
    
    

}