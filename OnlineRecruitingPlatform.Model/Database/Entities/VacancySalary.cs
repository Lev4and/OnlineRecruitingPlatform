using System;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class VacancySalary
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        
        [JsonProperty("vacancyId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid VacancyId { get; set; }
        
        [JsonProperty("currencyId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid CurrencyId { get; set; }
        
        [JsonProperty("upperWageLimit")]
        public int? UpperWageLimit { get; set; }
        
        [JsonProperty("lowerWageLimit")]
        public int? LowerWageLimit { get; set; }
        
        [JsonProperty("gross")]
        public bool? Gross { get; set; }
        
        [JsonProperty("vacancy")]
        public Vacancy Vacancy { get; set; }
        
        [JsonProperty("currency")]
        public Currency Currency { get; set; }
    }
}