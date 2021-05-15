using System;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class VacancySalary
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }
        
        [JsonProperty("vacancyId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid VacancyId { get; set; }
        
        [JsonProperty("currencyId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid CurrencyId { get; set; }
        
        [JsonProperty("upperWageLimit")]
        public virtual int? UpperWageLimit { get; set; }
        
        [JsonProperty("upperWageLimitRubles")]
        public virtual int? UpperWageLimitRubles { get; set; }

        [JsonProperty("lowerWageLimit")]
        public virtual int? LowerWageLimit { get; set; }
        
        [JsonProperty("lowerWageLimitRubles")]
        public virtual int? LowerWageLimitRubles { get; set; }
        
        [JsonProperty("bonus")]
        public virtual double Bonus { get; set; }
        
        [JsonProperty("gross")]
        public virtual bool? Gross { get; set; }
        
        [JsonProperty("vacancy")]
        public Vacancy Vacancy { get; set; }
        
        [JsonProperty("currency")]
        public virtual Currency Currency { get; set; }
    }

    public class VacancySalaryIV : VacancySalary
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid VacancyId { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid CurrencyId { get; set; }

        [JsonProperty("gross")]
        public override bool? Gross { get; set; }

        [JsonProperty("to")]
        public override int? UpperWageLimit { get; set; }

        [JsonProperty("from")]
        public override int? LowerWageLimit { get; set; }

        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }

        [JsonIgnore]
        [JsonProperty()]
        public override Currency Currency { get; set; }
    }
}