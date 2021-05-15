using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Specialization : IImportedFromHeadHunter<string>, IImportedFromZarplataRu<int?>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("professionalAreaId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid ProfessionalAreaId { get; set; }
        
        [MaxLength(6)]
        [JsonProperty("code")]
        public virtual string Code { get; set; }
        
        [Required]
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public virtual string IdentifierFromHeadHunter { get; set; }

        [JsonProperty("identifierFromZarplataRu")]
        public virtual int? IdentifierFromZarplataRu { get; set; }
        
        [JsonProperty("professionalArea")]
        public ProfessionalArea ProfessionalArea { get; set; }
        
        [JsonProperty("vacancySpecializations")]
        public ICollection<VacancySpecialization> VacancySpecializations { get; set; }
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

    public class SpecializationIVZarplataRu : Specialization
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid ProfessionalAreaId { get; set; }

        [JsonProperty()]
        public override string Code { get; set; }

        [JsonProperty("title")]
        public override string Name { get; set; }

        [JsonProperty("id")] 
        public override int? IdentifierFromZarplataRu { get; set; }

        [JsonProperty()]
        public override string IdentifierFromHeadHunter { get; set; }
    }
}
