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
        public virtual Guid Id { get; set; }
        
        [JsonProperty("vacancyContactId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid VacancyContactId { get; set; }
        
        [MaxLength(1)]
        [JsonProperty("countryCode")]
        public virtual string CountryCode { get; set; }
        
        [MaxLength(3)]
        [JsonProperty("cityCode")]
        public virtual string CityCode { get; set; }

        [MaxLength(7)]
        [JsonProperty("number")]
        public string Number { get; set; }
        
        [JsonProperty("phone")]
        public string Phone { get; set; } 
        
        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("formatted")]
        public string Formatted { get; set; } 
        
        [JsonProperty("vacancyContact")]
        public VacancyContact VacancyContact { get; set; }
    }

    public class VacancyContactPhoneIV : VacancyContactPhone
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid VacancyContactId { get; set; }

        [JsonProperty("country")]
        public override string CountryCode { get; set; }

        [JsonProperty("city")]
        public override string CityCode { get; set; }
    }
}