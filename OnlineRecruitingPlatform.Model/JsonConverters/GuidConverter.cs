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
                var stringResult = serializer.Deserialize<string>(reader);
                var guidResult = Guid.Empty;

                Guid.TryParse(stringResult, out guidResult);

                return guidResult;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
