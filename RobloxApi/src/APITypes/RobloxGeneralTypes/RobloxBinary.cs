using System.Text.Json;
using System.Text.Json.Serialization;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi.APITypes.RobloxGeneralTypes;

[JsonConverter(typeof(RobloxBytesConverter))]
public struct RobloxBinary
{
    public string BinaryString { get; set; }

    public RobloxBinary(object obj, string binaryString)
    {
        BinaryString = Convert.ToBase64String(Serializer.ConvertObjectToBytes(obj)).TrimEnd('=');
    }

    public RobloxBinary(string bytes)
    {
        if (bytes == null)
            throw new ArgumentNullException(nameof(bytes));
        if (string.IsNullOrWhiteSpace(bytes))
        {
            BinaryString = string.Empty;
            return;
        }

        Span<byte> span = new byte[bytes.Length];
        if (Convert.TryFromBase64String(bytes, span, out _))
            throw new ArgumentException("Invalid Base64 string provided.");
        BinaryString = bytes;
    }

    public override string ToString()
    {
        return BinaryString;
    }
}

public class RobloxBytesConverter : JsonConverter<RobloxBinary>
{
    public override RobloxBinary Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new RobloxBinary(reader.GetString() ?? "");
    }

    public override void Write(Utf8JsonWriter writer, RobloxBinary value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}