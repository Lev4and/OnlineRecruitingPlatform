using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ProfessionalArea : IImportedFromHeadHunter<string>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(2)]
        [JsonProperty("code")]
        public string Code { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("identifierFromHeadHunter")]
        public string IdentifierFromHeadHunter { get; set; }

        [JsonProperty("specializations")]
        public Specialization[] Specializations { get; set; }
    }
}
