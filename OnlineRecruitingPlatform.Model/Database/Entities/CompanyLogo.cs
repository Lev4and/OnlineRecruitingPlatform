using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class CompanyLogo
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("companyId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid CompanyId { get; set; }

        [JsonProperty("resolution90px")]
        public virtual string Resolution90px { get; set; }

        [JsonProperty("resolution240px")]
        public virtual string Resolution240px { get; set; }

        [JsonProperty("original")]
        public virtual string Original { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }
    }

    public class CompanyLogoIV : CompanyLogo
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid CompanyId { get; set; }

        [JsonProperty("90")]
        [JsonConverter(typeof(Base64Converter))]
        public override string Resolution90px { get; set; }

        [JsonProperty("240")]
        [JsonConverter(typeof(Base64Converter))]
        public override string Resolution240px { get; set; }

        [JsonProperty("original")]
        [JsonConverter(typeof(Base64Converter))]
        public override string Original { get; set; }
    }
}
