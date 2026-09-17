using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes.TypeBases;

namespace RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;

public class DataStoreList : ListResponseBase<DataStoreInfo>
{
    [JsonPropertyName("dataStores")] public override DataStoreInfo[]? List { get; set; }
}