using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Specialization : IImportedFromHeadHunter<string>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("professionalAreaId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid ProfessionalAreaId { get; set; }
        
        [Required]
        [MaxLength(6)]
        [JsonProperty("code")]
        public virtual string Code { get; set; }
        
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public virtual string IdentifierFromHeadHunter { get; set; }

        [JsonProperty("professionalArea")]
        public ProfessionalArea ProfessionalArea { get; set; }
        
        [JsonProperty("vacancySpecializations")]
        public VacancySpecialization[] VacancySpecializations { get; set; }
    }

    public class SpecializationIV : Specialization
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid ProfessionalAreaId { get; set; }

        [JsonProperty()]
        public override string Code { get; set; }

        [JsonProperty("id")]
        public override string IdentifierFromHeadHunter { get; set; }
    }
}
