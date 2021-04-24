using Newtonsoft.Json;
using System;

namespace OnlineRecruitingPlatform.Model.JsonConverters
{
    public class GuidConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(Guid));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                Guid guidResult;
                Guid.TryParse(serializer.Deserialize<string>(reader), out guidResult);

                return guidResult;
            }
            catch
            {
                return default(Guid);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
