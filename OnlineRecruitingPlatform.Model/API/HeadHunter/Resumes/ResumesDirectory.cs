using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Resumes
{
    public class ResumesDirectory
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
        public dynamic[] Resumes { get; set; }
    }
}
