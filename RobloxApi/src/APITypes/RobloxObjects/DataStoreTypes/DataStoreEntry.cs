using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;
using RobloxCloudApi.Helpers.JsonConverters;
using RobloxCloudApi.Helpers.JsonConverters.RequestV2Helpers;

namespace RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;

public class DataStoreEntry : ApiBaseData
{
    /// <summary>
    ///     State of an entry
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<DataStoreState>))] [JsonPropertyName("state")]
    public DataStoreState? State;

    [JsonPropertyName("createTime")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("expireTime")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? ExpirationTime { get; set; }

    [JsonPropertyName("revisionId")] public string? RevisionId { get; set; }

    [JsonPropertyName("revisionCreateTime")]
    [JsonConverter(typeof(DateTimeIso8601Converter))]
    public DateTime? RevisionCreationTime { get; set; }

    [JsonPropertyName("etag")] public string? ETag { get; set; }

    /// <summary>
    ///     Serialized value of a entry
    /// </summary>
    [JsonPropertyName("value")]
    public object? Value { get; set; }

    [JsonPropertyName("id")] public string? Id { get; set; }

    [JsonPropertyName("users")]
    [JsonConverter(typeof(UserApiPathArrayConverter))]
    public long[]? Users { get; set; }

    [JsonPropertyName("attributes")] public object? Attributes { get; set; }
}