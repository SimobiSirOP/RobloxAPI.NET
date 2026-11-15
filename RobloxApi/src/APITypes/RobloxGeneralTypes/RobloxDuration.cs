using System.Text.Json;
using System.Text.Json.Serialization;

namespace RobloxCloudApi.APITypes.RobloxGeneralTypes;

[JsonConverter(typeof(RobloxDurationConverter))]
public struct RobloxDuration
{
    public static long MaximumDuration
    {
        get
        {
            var maximumDate = new DateTimeOffset(9999, 1, 1, 1, 0, 0, TimeSpan.Zero);
            var timeSpan =
                maximumDate - DateTimeOffset.UtcNow;
            return (long)timeSpan.TotalSeconds;
        }
    }

    public string Duration { get; set; }


    public RobloxDuration(double duration)
    {
        if (duration < -MaximumDuration || duration > MaximumDuration)
            throw new ArgumentOutOfRangeException(nameof(duration));

        Duration = duration + "s";
    }

    public RobloxDuration(long duration)
    {
        if (duration < -MaximumDuration || duration > MaximumDuration)
            throw new ArgumentOutOfRangeException(nameof(duration));

        Duration = duration + "s";
    }

    public RobloxDuration(string durationStr)
    {
        if (!durationStr.EndsWith("s")) throw new ArgumentException("Duration string must ends with 's'.");

        if (!double.TryParse(durationStr.Substring(0, durationStr.Length - 1), out _))
            throw new ArgumentException("Duration is not a number.");

        Duration = durationStr;
    }

    // To double and from
    public static implicit operator RobloxDuration(double degrees)
    {
        return new RobloxDuration(degrees);
    }

    public static implicit operator double(RobloxDuration duration)
    {
        return double.Parse(duration.Duration.Substring(0,
            duration.Duration.Length - 1));
    }
    

    // to string and from
    public static implicit operator string(RobloxDuration duration)
    {
        return duration.Duration;
    }

    public static implicit operator RobloxDuration(string duration)
    {
        return new RobloxDuration(duration);
    }

    public override string ToString()
    {
        return Duration;
    }
}

public class RobloxDurationConverter : JsonConverter<RobloxDuration>
{
    public override RobloxDuration Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new RobloxDuration(reader.GetString() ?? "0s");
    }

    public override void Write(Utf8JsonWriter writer, RobloxDuration value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}