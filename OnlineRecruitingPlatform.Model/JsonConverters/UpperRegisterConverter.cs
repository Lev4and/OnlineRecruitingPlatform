using Newtonsoft.Json;
using System;

namespace OnlineRecruitingPlatform.Model.JsonConverters
{
    public class UpperRegisterConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return serializer.Deserialize<string>(reader).ToUpper();
            }
            catch
            {
                return string.Empty;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
