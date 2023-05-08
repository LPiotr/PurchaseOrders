using System.Text.Json;
using System.Text.Json.Serialization;

namespace SearchOrders.Data.Transformations
{
    public class DateTransformation
    {
        private JsonSerializerOptions options = new JsonSerializerOptions();


        public void SetDateConverter()
        {
            options.Converters.Add(new DateConverter());
        }

        private class DateConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TryGetDateTime(out DateTime dateTime))
                {
                    return dateTime;
                }
                throw new JsonException();
            }

            public override void Write(Utf8JsonWriter writer, DateTime dateTime, JsonSerializerOptions options)
            {
                writer.WriteStringValue(dateTime.ToString("dd.MM.yyyy"));
            }
        }
    }
}
