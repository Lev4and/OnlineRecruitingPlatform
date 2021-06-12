using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Company : IImportedFromHeadHunter<int?>, IImportedFromAvitoRu<int?>, IImportedFromZarplataRu<int?>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("isHr")]
        public bool? IsHr { get; set; }

        [JsonProperty("isHolding")]
        public bool? IsHolding { get; set; }

        [JsonProperty("isBlocked")]
        public bool? IsBlocked { get; set; }

        [JsonProperty("isCommerce")]
        public bool? IsCommerce { get; set; }

        [JsonProperty("isBlacklisted")]
        public bool? IsBlacklisted { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("modifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [JsonProperty("identifierFromAvitoRu")]
        public int? IdentifierFromAvitoRu { get; set; }

        [JsonProperty("identifierFromZarplataRu")]
        public int? IdentifierFromZarplataRu { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public virtual int? IdentifierFromHeadHunter { get; set; }

        [JsonProperty("logo")]
        public CompanyLogo Logo { get; set; }

        [JsonProperty("information")]
        public CompanyInformation Information { get; set; }

        [JsonProperty("relations")]
        public ICollection<CompanyRelation> Relations { get; set; }

        [JsonProperty("locations")]
        public ICollection<CompanyLocation> Locations { get; set; }

        [JsonProperty("companyPhotos")]
        public ICollection<CompanyPhoto> CompanyPhotos { get; set; }

        [JsonProperty("companyContacts")]
        public ICollection<CompanyContact> CompanyContacts { get; set; }

        [JsonProperty("subIndustries")]
        public ICollection<CompanySubIndustry> SubIndustries { get; set; }

        [JsonProperty("insiderInterviews")]
        public ICollection<CompanyInsiderInterview> InsiderInterviews { get; set; }

        [JsonProperty("vacancies")]
        public ICollection<Vacancy> Vacancies { get; set; }
        
        public ICollection<ResumeExperience> ResumeExperiences { get; set; }
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
