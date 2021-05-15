using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Experience : IImportedFromHeadHunter<string>, IImportedFromAvitoRu<string>, IImportedFromZarplataRu<int?>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

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
    }

    public class ExperienceIV : Experience 
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("id")]
        public override string IdentifierFromHeadHunter { get; set; }
    }

    public class ExperienceIVAvitoRu : Experience
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("id")]
        public override string IdentifierFromAvitoRu { get; set; }
    }

    public class ExperienceIVZarplataRu : Experience
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("title")]
        public override string Name { get; set; }

        [JsonProperty("id")] 
        public override int? IdentifierFromZarplataRu { get; set; }
    }
}
