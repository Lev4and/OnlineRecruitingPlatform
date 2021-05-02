using Newtonsoft.Json;
using System;

namespace OnlineRecruitingPlatform.Model.API.CbrXmlDaily
{
    public class DailyCurrencyQuotes
    {
        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("Valute")]
        public CurrencyQuoteDirectory CurrencyQuoteDirectory { get; set; }
    }
}
