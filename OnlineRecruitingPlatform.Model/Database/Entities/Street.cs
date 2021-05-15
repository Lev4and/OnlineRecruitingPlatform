using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Street : IImportedFromHeadHunter<int?>, IHaveAddressClassifierParentFromHeadHunter
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }
        
        [JsonProperty("areaId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid AreaId { get; set; }
        
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
        
        [JsonProperty("area")]
        public Area Area { get; set; }
        
        [JsonProperty("addresses")]
        public ICollection<Address> Addresses { get; set; }
        
        [JsonProperty("buildings")]
        public ICollection<Building> Buildings { get; set; }
    }

    public class StreetIV : Street
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid AreaId { get; set; }

        [JsonProperty("id")]
        public override int? IdentifierFromHeadHunter { get; set; }

        [JsonProperty("parent_id")]
        public override int? IdentifierParentFromHeadHunter { get; set; }
    }
}