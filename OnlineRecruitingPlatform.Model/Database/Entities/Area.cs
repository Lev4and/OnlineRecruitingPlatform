using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Area : IImportedFromHeadHunter<int?>, IImportedFromZarplataRu<int?>, IHaveAddressClassifierParentFromHeadHunter, IHaveAddressClassifierParentFromZarplataRu, ISupportAssociationWithFIAS
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("regionId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid RegionId { get; set; }

        [JsonProperty("aoguid")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? Aoguid { get; set; }

        [Required]
        [JsonProperty("name")]
        public virtual string Name { get; set; }
        
        [JsonProperty("identifierFromZarplataRu")]
        public virtual int? IdentifierFromZarplataRu { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public virtual int? IdentifierFromHeadHunter { get; set; }
        
        [JsonProperty("identifierParentFromZarplataRu")]
        public virtual int? IdentifierParentFromZarplataRu { get; set; }

        [JsonProperty("identifierParentFromHeadHunter")]
        public virtual int? IdentifierParentFromHeadHunter { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }
        
        [JsonProperty("addresses")]
        public ICollection<Address> Addresses { get; set; }

        [JsonProperty("vacancies")]
        public ICollection<Vacancy> Vacancies { get; set; }
        
        [JsonProperty("streets")]
        public ICollection<Street> Streets { get; set; }

        [JsonProperty("companyLocations")]
        public ICollection<CompanyLocation> CompanyLocations { get; set; }
    }

    public class AreaIV : Area
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid RegionId { get; set; }

        [JsonProperty("id")]
        public override int? IdentifierFromHeadHunter { get; set; }

        [JsonProperty("parent_id")]
        public override int? IdentifierParentFromHeadHunter { get; set; }
    }

    public class AreaIVZarplataRu : Area
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid RegionId { get; set; }

        [JsonProperty("id")] 
        public override int? IdentifierFromZarplataRu { get; set; }

        [JsonProperty("title")]
        public override string Name { get; set; }
    }
}
