using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class CompanyLocation
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        [JsonProperty("companyId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid CompanyId { get; set; }

        [JsonProperty("areaId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid AreaId { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("area")]
        public Area Area { get; set; }
    }

    public class CompanyLocationIV
    {
        [JsonProperty("id")]
        public int Area { get; set; }
    }
}
