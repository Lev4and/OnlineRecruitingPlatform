﻿using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class LanguageLevel : IImportedFromHeadHunter<string>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [Required]
        [JsonProperty("designation")]
        [JsonConverter(typeof(UpperRegisterConverter))]
        public string Designation { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifierfromheadhunter")]
        public virtual string IdentifierFromHeadHunter { get; set; }
    }

    public class LanguageLevelIV : LanguageLevel
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("id")]
        public override string IdentifierFromHeadHunter 
        { 
            get => base.IdentifierFromHeadHunter; 
            set
            {
                base.Designation = value.ToUpper();
                base.IdentifierFromHeadHunter = value;
            } 
        }
    }
}
