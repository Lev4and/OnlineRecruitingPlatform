using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Skill : IImportedFromHeadHunter<int?>, IImportedFromZarplataRu<int?>
    {
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("text")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int? IdentifierFromHeadHunter { get; set; }

        public int? IdentifierFromZarplataRu { get; set; }
    }
}
