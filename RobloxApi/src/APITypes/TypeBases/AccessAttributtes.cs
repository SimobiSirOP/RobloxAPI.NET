namespace RobloxCloudApi.APITypes.TypeBases;

[AttributeUsage(AttributeTargets.Class)]
public class UserCookieAuth : Attribute
{
}

[AttributeUsage(AttributeTargets.Class)]
public class ApiTokenAuth : Attribute
{
}

[AttributeUsage(AttributeTargets.Class)]
public class NoAuth : Attribute
{
}