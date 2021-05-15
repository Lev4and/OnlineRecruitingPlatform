using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Region : IImportedFromHeadHunter<int?>, IHaveAddressClassifierParentFromHeadHunter, ISupportAssociationWithFIAS
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("countryId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid CountryId { get; set; }

        [JsonProperty("aoguid")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? Aoguid { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public virtual int? IdentifierFromHeadHunter { get; set; }

        [JsonProperty("identifierParentFromHeadHunter")]
        public virtual int? IdentifierParentFromHeadHunter { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("areas")]
        public ICollection<Area> Areas { get; set; }
    }

    public class RegionIV : Region
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid CountryId { get; set; }

        [JsonProperty("id")]
        public override int? IdentifierFromHeadHunter { get; set; }

        [JsonProperty("parent_id")]
        public override int? IdentifierParentFromHeadHunter { get; set; }
    }
}
