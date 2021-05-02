using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Currency : IImportedFromHeadHunter<string>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [Required]
        [JsonProperty("code")]
        public string Code { get; set; }

        [Required]
        [JsonProperty("abbreviation")]
        public virtual string Abbreviation { get; set; }

        [Required]
        [JsonProperty("designation")]
        public string Designation { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public virtual string IdentifierFromHeadHunter { get; set; }
        
        [JsonProperty("currencyQuotes")]
        public CurrencyQuote[] CurrencyQuotes { get; set; }
        
        [JsonProperty("vacancySalaries")]
        public VacancySalary[] VacancySalaries { get; set; }
    }

    public class CurrencyIV : Currency
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [Required]
        [JsonProperty("abbr")]
        public override string Abbreviation { get; set; }

        [JsonProperty("code")]
        public override string IdentifierFromHeadHunter { get; set; }
    }
}
