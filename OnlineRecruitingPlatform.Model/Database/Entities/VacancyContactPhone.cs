using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class VacancyContactPhone
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        
        [JsonProperty("vacancyContactId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid VacancyContactId { get; set; }
        
        [Required]
        [MaxLength(1)]
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        
        [Required]
        [MaxLength(3)]
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }
        
        [Required]
        [MaxLength(7)]
        [JsonProperty("number")]
        public string Number { get; set; }
        
        [JsonProperty("comment")]
        public string Comment { get; set; }
        
        [JsonProperty("vacancyContact")]
        public VacancyContact VacancyContact { get; set; }
    }
}