using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class VacancyType : IImportedFromHeadHunter<string>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public virtual Guid Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("identifierFromHeadHunter")]
        public virtual string IdentifierFromHeadHunter { get; set; }

        [JsonProperty("vacancies")]
        public Vacancy[] Vacancies { get; set; }
    }

    public class VacancyTypeIV : VacancyType
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidNullableConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("id")]
        public override string IdentifierFromHeadHunter { get; set; }
    }
}
