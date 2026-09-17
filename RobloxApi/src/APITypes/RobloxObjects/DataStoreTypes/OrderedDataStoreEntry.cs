using System.Text.Json.Serialization;
using RobloxCloudApi.APIRequests.Abstractions;

namespace RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;

public class OrderedDataStoreEntry : ApiBaseData
{
    /// <summary>
    ///  Value of the entry
    /// </summary>
    [JsonPropertyName("value")]
    public long? Value { get; set; }

    [JsonPropertyName("id")] public string? Id { get; set; }
    
}