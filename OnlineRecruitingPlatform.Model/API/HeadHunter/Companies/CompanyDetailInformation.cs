using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Companies
{
    public class CompanyDetailInformation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("site_url")]
        public string SiteUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("branded_description")]
        public string BrandedDescription { get; set; }

        [JsonProperty("relations")]
        public string[] Relations { get; set; }

        [JsonProperty("logo_urls")]
        public CompanyLogoIV Logo { get; set; }

        [JsonProperty("area")]
        public CompanyLocationIV Location { get; set; }

        [JsonProperty("industries")]
        public CompanySubIndustryIV[] SubIndustries { get; set; }

        [JsonProperty("insider_interviews")]
        public CompanyInsiderInterviewIV[] InsiderInterviews { get; set; }
    }
}
