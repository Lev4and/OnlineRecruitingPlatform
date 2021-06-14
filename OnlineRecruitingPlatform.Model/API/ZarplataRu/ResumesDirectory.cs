using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.Model.API.ZarplataRu
{
    public class ResumesDirectory
    {
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("companies")]
        public dynamic[] Resumes { get; set; }
    }
}
