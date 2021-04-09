using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class LanguageLevel
    {
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("id")]
        public string Designation { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
