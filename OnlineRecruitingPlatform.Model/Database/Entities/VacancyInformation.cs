using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class VacancyInformation
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        
        [JsonProperty("vacancyId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid VacancyId { get; set; }
        
        [JsonProperty("vacancyBillingTypeId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid VacancyBillingTypeId { get; set; }
        
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("brandedDescription")]
        public string BrandedDescription { get; set; }
        
        [JsonProperty("hasTest")]
        public bool? HasTest { get; set; }
        
        [JsonProperty("vacancy")]
        public Vacancy Vacancy { get; set; }
        
        [JsonProperty("vacancyBillingType")]
        public VacancyBillingType VacancyBillingType { get; set; }
    }
}