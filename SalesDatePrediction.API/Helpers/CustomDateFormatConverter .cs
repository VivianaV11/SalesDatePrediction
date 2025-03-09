using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SalesDatePrediction.API.Helpers;

public class CustomDateFormatConverter : JsonConverter<DateTime?>
{
    private readonly string _format = "M/d/yyyy";

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String &&
            DateTime.TryParseExact(reader.GetString(), _format, null, System.Globalization.DateTimeStyles.None, out var date))
        {
            return date;
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString(_format));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
