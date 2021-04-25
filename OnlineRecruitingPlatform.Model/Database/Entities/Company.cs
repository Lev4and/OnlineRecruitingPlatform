using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Company : IImportedFromHeadHunter<int?>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public virtual int? IdentifierFromHeadHunter { get; set; }

        [JsonProperty("information")]
        public CompanyInformation Information { get; set; }

        [JsonProperty("logo")]
        public CompanyLogo Logo { get; set; }

        [JsonProperty("relations")]
        public CompanyRelation[] Relations { get; set; }

        [JsonProperty("locations")]
        public CompanyLocation[] Locations { get; set; }

        [JsonProperty("subIndustries")]
        public CompanySubIndustry[] SubIndustries { get; set; }

        [JsonProperty("insiderInterviews")]
        public CompanyInsiderInterview[] InsiderInterviews { get; set; }
    }

    public class CompanyIV : Company
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("id")]
        public override int? IdentifierFromHeadHunter { get; set; }
    }
}
