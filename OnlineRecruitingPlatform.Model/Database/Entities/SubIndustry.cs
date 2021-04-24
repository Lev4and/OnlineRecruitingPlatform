using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class SubIndustry
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("industryId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid IndustryId { get; set; }

        [Required]
        [MaxLength(8)]
        [JsonProperty("code")]
        public virtual string Code { get; set; } 

        [Required]
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("industry")]
        public Industry Industry { get; set; }
    }

    public class SubIndustryIV : SubIndustry
    {
        [JsonIgnore]
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [Required]
        [MaxLength(8)]
        [JsonProperty("kod")]
        public override string Code { get; set; }
    }

    public class SubIndustryIVDataDovRu : SubIndustry
    {
        [JsonIgnore]
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [Required]
        [MaxLength(8)]
        [JsonProperty("Kod")]
        public override string Code { get; set; }

        [Required]
        [JsonProperty("Name")]
        public override string Name { get; set; }
    }

    public class SubIndustryIVDataMosRu : SubIndustry
    {
        [JsonIgnore]
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [Required]
        [MaxLength(8)]
        [JsonProperty("Kod")]
        public override string Code { get; set; }

        [Required]
        [JsonProperty("Name")]
        public override string Name { get; set; }
    }
}
