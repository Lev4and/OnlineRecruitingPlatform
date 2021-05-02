using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.Model.API.CbrXmlDaily
{
    public class CurrencyQuote
    {
        [JsonProperty("Nominal")]
        public int Nominal { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("CharCode")]
        public string CharCode { get; set; }
    }
}
