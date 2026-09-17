using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;

public class DataStoreEntryList : ListResponseBase<DataStoreEntry>
{
    [JsonPropertyName("dataStoreEntries")] public override DataStoreEntry[]? List { get; set; }
}