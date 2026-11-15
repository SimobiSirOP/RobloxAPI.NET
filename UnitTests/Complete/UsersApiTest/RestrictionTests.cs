using RobloxCloudApi;
using RobloxCloudApi.APITypes.RobloxObjects.Users;
using RobloxCloudApi.Helpers;

namespace UnitTests.Complete.UsersApiTest;

[TestFixture]
[Category("Complete")]
public class RestrictionTests
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
    [Order(0)]
    public async Task TestUserBanPerm()
    {
        var ban = await _client.Users.BanUserFromUniverse(_testUser.UserId, Globals.TestUniverseId, null, "Test ban", "Test ban reason");
        if (ban.GameJoinRestriction != null && !ban.GameJoinRestriction.Active)
        {
            Assert.Fail("Ban not active");
        }
        Assert.Pass(Serializer.SerializeToString(ban));
    }
    
    [Test]
        [Order(1)]
        public async Task TestUserBanOneDay()
        {
            var ban = await _client.Users.BanUserFromUniverse(_testUser.UserId, Globals.TestUniverseId, 3600 * 24, "Test ban", "Test ban reason");
            if (ban.GameJoinRestriction != null && !ban.GameJoinRestriction.Active)
            {
                Assert.Fail("Ban not active");
            }
            Assert.Pass(Serializer.SerializeToString(ban));
        }
        
        [Test]
        [Order(2)]
        public async Task TestUserListRestriction()
        {
            var ban = await _client.Users.ListRestrictionLogsByUser(Globals.TestUniverseId, _testUser.UserId);

            if (ban.List == null)
            {
                Assert.Fail("Ban list is empty or doesn't exist");
                return;
            }

            if (ban.List.Length < 1)
            {
                Assert.Fail("No restriction logs found");
                return;
            }
            Assert.Pass(Serializer.SerializeToString(ban));
        }
    
    
    [Test]
    [Order(222)]
    public async Task TestUserUnban()
    {
        var unban = await _client.Users.UnbanUserFromUniverse(_testUser.UserId, Globals.TestUniverseId);
        
        if (unban.GameJoinRestriction != null && unban.GameJoinRestriction.Active)
        {
            Assert.Fail("Ban is active after unban");
        }
        
        Assert.Pass(Serializer.SerializeToString(unban));
    }
    
    
    

}