using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ProfessionalArea : IImportedFromHeadHunter<string>, IImportedFromZarplataRu<int?>, IImportedFromAvitoRu<string>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }
        
        [MaxLength(2)]
        [JsonProperty("code")]
        public virtual string Code { get; set; }

        [Required]
        [JsonProperty("name")]
        public virtual string Name { get; set; }
        
        [JsonProperty("identifierFromZarplataRu")]
        public virtual int? IdentifierFromZarplataRu { get; set; }
        
        [JsonProperty("identifierFromHeadHunter")]
        public virtual string IdentifierFromHeadHunter { get; set; }

        [JsonProperty("identifierFromAvitoRu")]
        public virtual string IdentifierFromAvitoRu { get; set; }

        [JsonProperty("vacancies")]
        public ICollection<Vacancy> Vacancies { get; set; }

        [JsonProperty("specializations")]
        public ICollection<Specialization> Specializations { get; set; }
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

    public class ProfessionalAreaIVAvitoRu : ProfessionalArea
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        public override string Code { get; set; }

        [JsonProperty()]
        public override string IdentifierFromHeadHunter { get; set; }

        [JsonProperty("id")]
        public override string IdentifierFromAvitoRu { get; set; }
    }

    public class ProfessionalAreaIVZarplataRuWithSpecializations : ProfessionalArea
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        public override string Code { get; set; }

        [JsonProperty("title")]
        public override string Name { get; set; }

        [JsonProperty("id")]
        public override int? IdentifierFromZarplataRu { get; set; }

        [JsonProperty()]
        public override string IdentifierFromHeadHunter { get; set; }
        
        [JsonProperty()]
        public override string IdentifierFromAvitoRu { get; set; }

        [JsonProperty("specialities")]
        public SpecializationIVZarplataRu[] SpecializationsFromZarplataRu { get; set; }
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
