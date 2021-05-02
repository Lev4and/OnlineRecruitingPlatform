using System;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class VacancySpecialization
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        
        [JsonProperty("vacancyId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid VacancyId { get; set; }
        
        [JsonProperty("specializationId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid SpecializationId { get; set; }
        
        [JsonProperty("vacancy")]
        public Vacancy Vacancy { get; set; }
        
        [JsonProperty("specialization")]
        public Specialization Specialization { get; set; }
    }
}