using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Specialization
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        [JsonProperty("professionalAreaId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid ProfessionalAreaId { get; set; }
        
        [Required]
        [MaxLength(6)]
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("professionalArea")]
        public ProfessionalArea ProfessionalArea { get; set; }
        
        [JsonProperty("vacancySpecializations")]
        public VacancySpecialization[] VacancySpecializations { get; set; }
    }
}
