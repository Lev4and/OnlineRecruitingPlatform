using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Vacancies
{
    public class VacanciesDirectory
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("pages")]
        public int Pages { get; set; }

        [JsonProperty("found")]
        public int Found { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("items")]
        public VacancyIV[] Vacancies { get; set; }
    }
}
