using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class VacancyVisibilityType : IImportedFromAvitoRu<string>
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
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}