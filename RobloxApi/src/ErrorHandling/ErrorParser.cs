using System.Text;
using System.Text.Json.Serialization;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.TypeBases;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi.ErrorHandling;

public static class ErrorParser
{
    public static async Task<string> GetErrorString(HttpResponseMessage response)
    {
        var error = Serializer.SerializeFromString<RobloxError>(await response.Content.ReadAsStringAsync());

        if (error.ErrorCode == null)
                return await GetErrorStringFromArray(response);
            
        return await GetBasicErrorString(response) + error;
    }

    private static async Task<string> GetErrorStringFromArray(HttpResponseMessage response)
    {
        var errorMessage =
            Serializer.SerializeFromString<ErrorResponseArray>(await response.Content.ReadAsStringAsync());
        if (errorMessage == null!)
            return await GetBasicErrorString(response);

        StringBuilder newErrorString = new(await GetBasicErrorString(response));
        
        if (errorMessage.List == null) return newErrorString.ToString();
        
        foreach (var error in errorMessage.List)
            newErrorString.AppendLine(error.ToString());
        return newErrorString.ToString();
    }

    private static async Task<string> GetBasicErrorString(HttpResponseMessage response)
    {
        return $"{(int)response.StatusCode}: {response.ReasonPhrase}\n";
    }

    private class ErrorResponseArray : ListResponseBase<RobloxError>
    {
        [JsonPropertyName("errors")] public override RobloxError[]? List { get; set; }
    }
}