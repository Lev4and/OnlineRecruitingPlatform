using System;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.ZarplataRu
{
    public class CompanyIV
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("is_hr")]
        public bool? IsHr { get; set; }

        [JsonProperty("is_holding")]
        public bool? IsHolding { get; set; }

        [JsonProperty("is_blocked")]
        public bool? IsBlocked { get; set; }

        [JsonProperty("is_commerce")]
        public bool? IsCommerce { get; set; }

        [JsonProperty("is_blacklisted")]
        public bool? IsBlacklisted { get; set; }

        [JsonProperty("title")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("external_url")]
        public string SiteUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string CardCompanyUrl { get; set; }

        [JsonProperty("add_date")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("mod_date")]
        public DateTime? ModifiedAt { get; set; }

        [JsonProperty("logo")]
        public CompanyLogoIVZarplataRu CompanyLogo { get; set; }

        [JsonProperty("companyPhotos")]
        public CompanyPhotoIVZarplataRu[] CompanyPhotos { get; set; }

        [JsonProperty("contacts")]
        public CompanyContactIVZarplataRu[] CompanyContacts { get; set; }

        [JsonProperty("interviews")]
        public CompanyInsiderInterviewIVZarplataRu[] CompanyInsiderInterviews { get; set; }
        
        [JsonProperty("rubrics")]
        public ProfessionalAreaIVZarplataRuWithSpecializations[] ProfessionalAreas { get; set; }
    }
}