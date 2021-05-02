﻿using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Profession
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [Required]
        [MaxLength(5)]
        [JsonProperty("code")]
        public virtual string Code { get; set; }

        [Required]
        [JsonProperty("name")]
        public virtual string Name { get; set; }
    }

    public class ProfessionIV : Profession
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("KOD")]
        public override string Code { get; set; }

        [Required]
        [JsonProperty("NAME")]
        public override string Name { get; set; }
    }
}