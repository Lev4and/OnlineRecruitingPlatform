using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class CompanySubIndustry
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        [JsonProperty("companyId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid CompanyId { get; set; }

        [JsonProperty("subIndustryId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid SubIndustryId { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("subIndustry")]
        public SubIndustry SubIndustry { get; set; }
    }

    public class CompanySubIndustryIV
    {
        [JsonProperty("id")]
        public string Code { get; set; }
    }
}
