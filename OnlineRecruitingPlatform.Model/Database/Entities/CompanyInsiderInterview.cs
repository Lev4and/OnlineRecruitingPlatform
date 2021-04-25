using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class CompanyInsiderInterview : IImportedFromHeadHunter<int?>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("companyId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid CompanyId { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public virtual int? IdentifierFromHeadHunter { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }
    }

    public class CompanyInsiderInterviewIV : CompanyInsiderInterview
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid CompanyId { get; set; }

        [JsonProperty("id")]
        public override int? IdentifierFromHeadHunter { get; set; }
    }
}
