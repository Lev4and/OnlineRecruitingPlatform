using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Schedule : IImportedFromHeadHunter<string>, IImportedFromAvitoRu<string>, IImportedFromZarplataRu<int?>
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
        
        public ICollection<ResumeSchedule> ResumeSchedules { get; set; }
    }

    public class ScheduleIV : Schedule
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("id")]
        public override string IdentifierFromHeadHunter { get; set; }
    }

    public class ScheduleIVAvitoRu : Schedule
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("id")]
        public override string IdentifierFromAvitoRu { get; set; }
    }

    public class ScheduleIVZarplataRu : Schedule
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("title")]
        public override string Name { get; set; }

        [JsonProperty("id")]
        public override int? IdentifierFromZarplataRu { get; set; }

        [JsonProperty()]
        public override string IdentifierFromHeadHunter { get; set; }

        [JsonProperty()]
        public override string IdentifierFromAvitoRu { get; set; }
    }
}
