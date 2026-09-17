using RobloxCloudApi.APIRequests.Abstractions;

namespace RobloxCloudApi.APITypes.TypeBases;

/// <summary>
///     Used for v1 api lists
/// </summary>
public abstract class OldListRequestBase<T> : RequestBase<T>
{
    [QueryParameter("cursor", true)] public string? Cursor { get; set; }

    [QueryParameter("sortOrder", true)] 
    [QueryEnumToString]
    public SortOrder? SortOrder { get; set; }

    [QueryParameter("limit", true)] public int? MaxPageSize { get; set; }
}

public enum SortOrder
{
    Asc,
    Desc
}