using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.Model.API.AvitoRu
{
    public class ParamsVacancy
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("schedule")]
        public string Schedule { get; set; }

        [JsonProperty("paid_period")]
        public string PayPeriod { get; set; }

        [JsonProperty("piecework_flag")]
        public string Piecework { get; set; }

        [JsonProperty("experience")]
        public string Experience { get; set; }

        [JsonProperty("where_to_work")]
        public string PlaceOfWork { get; set; }

        [JsonProperty("payout_frequency")]
        public string PayoutFrequency { get; set; }

        [JsonProperty("business_area")]
        public string ProfessionalArea { get; set; }

        [JsonProperty("age_preferences")]
        public string[] AgePreferences { get; set; }

        [JsonProperty("change")]
        public string[] WorkingShifts { get; set; }
    }
}
