using System;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class CurrencyQuote
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        
        [JsonProperty("currencyId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid CurrencyId { get; set; }
        
        [JsonProperty("nominal")]
        public int Nominal { get; set; }
        
        [JsonProperty("value")]
        public double Value { get; set; }
        
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        
        [JsonProperty("currency")]
        public Currency Currency { get; set; }
    }
}