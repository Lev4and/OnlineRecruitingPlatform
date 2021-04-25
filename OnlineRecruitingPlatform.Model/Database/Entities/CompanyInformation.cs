using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class CompanyInformation
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("companyId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid CompanyId { get; set; }

        [JsonProperty("siteUrl")]
        public virtual string SiteUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("brandedDescription")]
        public virtual string BrandedDescription { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }
    }

    public class CompanyInformationIV : CompanyInformation
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid CompanyId { get; set; }

        [JsonProperty("site_url")]
        public override string SiteUrl { get; set; }

        [JsonProperty("branded_description")]
        public override string BrandedDescription { get; set; }
    }
}
