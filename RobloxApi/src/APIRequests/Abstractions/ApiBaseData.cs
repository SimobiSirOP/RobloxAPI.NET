using System.Text.Json.Serialization;

namespace RobloxCloudApi.APIRequests.Abstractions;

/// <summary>
///     Class for V2 API Data without handled path databinding
/// </summary>
public abstract class ApiBaseData
{
    [JsonPropertyName("path")] public string? RequestPath { get; set; }
}