namespace RobloxCloudApi.APITypes.TypeBases;

[AttributeUsage(AttributeTargets.Class)]
public class UserCookieAuth : Attribute
{
    public UserCookieAuth()
    {}
}

[AttributeUsage(AttributeTargets.Class)]
public class ApiTokenAuth : Attribute
{
    public ApiTokenAuth()
    {}
}

[AttributeUsage(AttributeTargets.Class)]
public class NoAuth : Attribute
{
    public NoAuth()
    {}
}