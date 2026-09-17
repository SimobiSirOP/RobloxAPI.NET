using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;

public class OrderedDataStoreEntryList : ListResponseBase<OrderedDataStoreEntry>
{
    [JsonPropertyName("orderedDataStoreEntries")] public override OrderedDataStoreEntry[]? List { get; set; }
}