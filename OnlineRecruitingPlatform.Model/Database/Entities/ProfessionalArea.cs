using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ProfessionalArea : IImportedFromHeadHunter<string>, IImportedFromAvitoRu<string>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }
        
        [Required]
        [MaxLength(2)]
        [JsonProperty("code")]
        public virtual string Code { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("identifierFromHeadHunter")]
        public virtual string IdentifierFromHeadHunter { get; set; }

        [JsonProperty("identifierFromAvitoRu")]
        public string IdentifierFromAvitoRu { get; set; }

        [JsonProperty("vacancies")]
        public Vacancy[] Vacancies { get; set; }

        [JsonProperty("specializations")]
        public Specialization[] Specializations { get; set; }
    }

    public class ProfessionalAreaIV : ProfessionalArea
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        public override string Code { get; set; }

        [JsonProperty("id")]
        public override string IdentifierFromHeadHunter { get; set; }
    }

    public class ProfessionalAreaIVWithSpecializations
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        [JsonProperty()]
        public string Code { get; set; }

        [JsonProperty("id")]
        public string IdentifierFromHeadHunter { get; set; }

        [JsonProperty("specializations")]
        public SpecializationIV[] Specializations { get; set; }
    }
}
