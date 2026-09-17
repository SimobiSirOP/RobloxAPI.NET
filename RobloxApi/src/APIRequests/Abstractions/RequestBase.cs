using System.Collections;
using System.Text;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi.APIRequests.Abstractions;

public abstract class RequestBase<TResponse> : IRequest<TResponse>
{
    [JsonIgnore] public abstract HttpMethod HttpMethod { get; }

    [UriString]
    [JsonPropertyName("path")] public abstract string RequestPath { get; }

    public virtual HttpContent? GetHttpContent()
    {
        if (HttpMethod == HttpMethod.Get)
            return null;
        return new StringContent(Serializer.SerializeToString(this), Encoding.UTF8, "application/json");
    }

    public string GetRequestUri()
    {
        var properties = GetType().GetProperties()
            .Where(parameter => Attribute.IsDefined(parameter, typeof(QueryParameter)));

        var queryAdditionString = new StringBuilder();
        foreach (var parameter in properties)
        {
            var rawValue = parameter.GetValue(this);
            object? paramValue;
            if (rawValue != null && rawValue.GetType().IsEnum)
            {
                if (Attribute.IsDefined(parameter, typeof(QueryEnumToString)))
                    paramValue = rawValue.ToString();
                else
                    paramValue = (int)(rawValue);
            }
            else if (rawValue is IEnumerable enumerable && rawValue is not string)
                paramValue = string.Join(',', enumerable.Cast<object>());
            else paramValue = rawValue;


            var queryParameter =
                (QueryParameter)Attribute.GetCustomAttribute(parameter, typeof(QueryParameter))!;

            var paramName = queryParameter.Name ??  parameter.Name;

            if (queryAdditionString.Length > 0 && (!queryParameter.IgnoreWhenNull || paramValue != null))
                queryAdditionString.Append("&");

            if (paramValue != null)
                queryAdditionString.Append($"{paramName}={paramValue.ToString()}");
            else if (!queryParameter.IgnoreWhenNull)
                queryAdditionString.Append($"{paramName}");
        }

        if (queryAdditionString.Length > 0)
            return RequestPath + "?" + queryAdditionString;
        return RequestPath;
    }
}

[AttributeUsage(AttributeTargets.Property, Inherited = true)]
[MeansImplicitUse]
public class QueryParameter : Attribute
{
    public QueryParameter(string? name = null, bool ignoreWhenNull = false)
    {
        Name = name;
        IgnoreWhenNull = ignoreWhenNull;
    }

    public string? Name { get; }

    public bool IgnoreWhenNull { get; }
}

[AttributeUsage(AttributeTargets.Property)]
public class QueryEnumToString : Attribute
{
    public QueryEnumToString()
    {}
}