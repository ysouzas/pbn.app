using System.Text.Json;

namespace PBN.APP.Extensions;

public static class SerializerExtensions
{
    public static string Serialize<T>(this T objectToSerialize, JsonSerializerOptions options = null)
    {
        return JsonSerializer.Serialize(objectToSerialize, options);
    }

    public static T Deserialize<T>(this string json, JsonSerializerOptions options = null)
    {
        if (string.IsNullOrEmpty(json))
            return default;

        options ??= new() { PropertyNameCaseInsensitive = true };

        return JsonSerializer.Deserialize<T>(json, options);
    }
}
