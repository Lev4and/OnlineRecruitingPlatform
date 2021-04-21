using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class ExperiencesDirectory
    {
        [JsonProperty("experience")]
        public Experience[] Experiences { get; set; }
    }

    public class ExperiencesDirectory<T> where T : Experience
    {
        [JsonProperty("experience")]
        public T[] Experiences { get; set; }
    }
}
