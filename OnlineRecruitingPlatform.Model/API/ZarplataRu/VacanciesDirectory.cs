using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.Model.API.ZarplataRu
{
    public class VacanciesDirectory
    {
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("vacancies")]
        public VacancyIV[] Vacancies { get; set; }
    }
}
