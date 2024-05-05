using Newtonsoft.Json;

public class TimeOnlyConverter : JsonConverter<TimeOnly>
{
    public override TimeOnly ReadJson(JsonReader reader, Type objectType, TimeOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.String)
        {
            var value = reader.Value.ToString();
            if (TimeOnly.TryParse(value, out TimeOnly time))
            {
                return time;
            }
        }
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, TimeOnly value, JsonSerializer serializer)
    {
        var stringValue = value.ToString();
        writer.WriteValue(stringValue);
    }
}

