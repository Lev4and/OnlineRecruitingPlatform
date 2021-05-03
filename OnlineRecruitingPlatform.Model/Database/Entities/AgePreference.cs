using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class AgePreference : IImportedFromAvitoRu<string>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifierFromAvitoRu")]
        public string IdentifierFromAvitoRu { get; set; }

        [JsonProperty("vacancies")]
        public Vacancy[] Vacancies { get; set; }
    }
}
