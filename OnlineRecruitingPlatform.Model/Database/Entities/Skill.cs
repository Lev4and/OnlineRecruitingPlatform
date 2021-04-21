using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Skill : IImportedFromHeadHunter<int?>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("identifierfromheadhunter")]
        public virtual int? IdentifierFromHeadHunter { get; set; }
    }

    public class SkillIV : Skill
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [Required]
        [JsonProperty("text")]
        public override string Name { get; set; }

        [JsonProperty("id")]
        public override int? IdentifierFromHeadHunter { get; set; }
    }
}
