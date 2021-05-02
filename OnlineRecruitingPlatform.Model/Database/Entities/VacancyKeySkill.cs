using System;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class VacancyKeySkill
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        
        [JsonProperty("vacancyId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid VacancyId { get; set; }
        
        [JsonProperty("skillId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid SkillId { get; set; }
        
        [JsonProperty("vacancy")]
        public Vacancy Vacancy { get; set; }
        
        [JsonProperty("skill")]
        public Skill Skill { get; set; }
    }
}