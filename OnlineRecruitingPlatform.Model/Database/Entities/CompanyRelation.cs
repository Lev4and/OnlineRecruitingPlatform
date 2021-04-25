using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class CompanyRelation
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        [JsonProperty("companyId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid CompanyId { get; set; }

        [JsonProperty("relationId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid RelationId { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("relation")]
        public Relation Relation { get; set; }
    }
}
