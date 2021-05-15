using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;

namespace OnlineRecruitingPlatform.Model.API.CLADR
{
    public class Content
    {
        [JsonProperty("zip")]
        public int? Zip { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("okato")]
        public string OKATO { get; set; }

        [JsonProperty("oktmo")]
        public string OKTMO { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("typeShort")]
        public string TypeShort { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("guid")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? AoGuid { get; set; }

        [JsonProperty("parentGuid")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? ParentGuid { get; set; }

        [JsonProperty("parents")]
        public Content[] Parents { get; set; } 
    }
}
