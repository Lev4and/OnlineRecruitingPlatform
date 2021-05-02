using System;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class VacancyContact
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        
        [JsonProperty("vacancyId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid VacancyId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("vacancy")]
        public Vacancy Vacancy { get; set; }
        
        [JsonProperty("vacancyContactPhones")]
        public VacancyContactPhone[] VacancyContactPhones { get; set; }
    }
}