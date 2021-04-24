using Newtonsoft.Json;
using System;

namespace OnlineRecruitingPlatform.Model.JsonConverters
{
    public class GuidNullableConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                var stringResult = serializer.Deserialize<string>(reader);

                if (!string.IsNullOrEmpty(stringResult))
                {
                    Guid guidResult;
                    Guid.TryParse(serializer.Deserialize<string>(reader), out guidResult);

                    return (Guid?)guidResult;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(Guid?));
        }
    }
}
