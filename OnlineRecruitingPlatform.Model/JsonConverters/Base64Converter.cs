using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Downloaders;
using System;

namespace OnlineRecruitingPlatform.Model.JsonConverters
{
    public class Base64Converter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var urlToFile = serializer.Deserialize<string>(reader);

            if (!string.IsNullOrEmpty(urlToFile))
            {
                var fileDownloader = new FileDownloader(urlToFile);
                var response =  fileDownloader.Download().Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsByteArrayAsync().Result;
                    var base64 = Convert.ToBase64String(result);

                    return base64;
                }
                else
                {
                    return default(string);
                }
            }
            else
            {
                return default(string);
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(string));
        }
    }
}
