﻿using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Language : IImportedFromHeadHunter<string>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public virtual string IdentifierFromHeadHunter { get; set; }
        
        public ICollection<ResumeLanguage> ResumeLanguages { get; set; }
    }

    public class LanguageIV : Language
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("id")]
        public override string IdentifierFromHeadHunter { get; set; }
    }
}
