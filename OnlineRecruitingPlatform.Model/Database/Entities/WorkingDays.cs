﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class WorkingDays : IImportedFromHeadHunter<string>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public virtual string IdentifierFromHeadHunter { get; set; }
        
        public ICollection<Vacancy> Vacancies { get; set; }
    }

    public class WorkingDaysIV : WorkingDays
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("id")]
        public override string IdentifierFromHeadHunter { get; set; }
    }
}
