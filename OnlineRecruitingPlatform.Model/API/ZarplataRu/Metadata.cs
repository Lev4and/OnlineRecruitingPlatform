using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.Model.API.ZarplataRu
{
    public class Metadata
    {
        [JsonProperty("resultset")]
        public Resultset Resultset { get; set; }
    }
}
