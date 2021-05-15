using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Industry
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [Required]
        [MaxLength(2)]
        [JsonProperty("code")]
        public virtual string Code { get; set; }

        [Required]
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("subIndustries")]
        public ICollection<SubIndustry> SubIndustries { get; set; }
    }

    public class IndustryIV : Industry
    {
        [JsonIgnore]
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [Required]
        [MaxLength(2)]
        [JsonProperty("kod")]
        public override string Code { get; set; }
    }

    public class IndustryIVDataDovRu : Industry
    {
        [JsonIgnore]
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [Required]
        [MaxLength(2)]
        [JsonProperty("Kod")]
        public override string Code { get; set; }

        [Required]
        [JsonProperty("Name")]
        public override string Name { get; set; }
    }

    public class IndustryIVDataMosRu : Industry
    {
        [JsonIgnore]
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [Required]
        [MaxLength(2)]
        [JsonProperty("Kod")]
        public override string Code { get; set; }

        [Required]
        [JsonProperty("Name")]
        public override string Name { get; set; }
    }
}
