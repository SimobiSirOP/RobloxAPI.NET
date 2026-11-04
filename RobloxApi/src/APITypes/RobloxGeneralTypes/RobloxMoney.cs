using System.Text.Json.Serialization;

namespace RobloxCloudApi.APITypes.RobloxGeneralTypes;

public class RobloxMoney
{
    [JsonPropertyName("currencyCode")] public string? CurrencyCode { get; set; }

    [JsonPropertyName("quantity")] public RobloxDecimal Quantity { get; set; }
}

public struct RobloxDecimal
{
    [JsonPropertyName("significand")] public long Significand { get; set; }

    [JsonPropertyName("exponent")] public int Exponent { get; set; }

    public decimal ToDecimal()
    {
        return (decimal)Math.Pow(Significand, Exponent);
    }

    public RobloxDecimal()
    {
    }

    public RobloxDecimal(decimal value)
    {
        var bits = decimal.GetBits(value);

        Significand = (uint)bits[0] | ((long)bits[1] << 32);
        Exponent = (bits[3] >> 16) & 0x7F;
    }
}