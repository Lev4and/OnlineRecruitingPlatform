using Newtonsoft.Json;
using System;

namespace OnlineRecruitingPlatform.Model.API.AvitoRu
{
    public class VacancyIV
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("salary")]
        public int? Salary { get; set; }

        [JsonProperty("is_active")]
        public bool Archived { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("start_time")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("params")]
        public ParamsVacancy ParamsVacancy { get; set; }
    }
}
