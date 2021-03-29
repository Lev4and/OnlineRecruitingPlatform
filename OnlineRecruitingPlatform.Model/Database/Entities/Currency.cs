using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Currency
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("code")]
        public string Code { get; set; }

        [Required]
        [JsonProperty("abbr")]
        public string Abbreviation { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
