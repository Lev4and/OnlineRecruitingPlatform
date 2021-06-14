using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.Model.API.ZarplataRu
{
    public class CompaniesDirectory
    {
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("companies")]
        public dynamic[] Companies { get; set; }
    }
}
