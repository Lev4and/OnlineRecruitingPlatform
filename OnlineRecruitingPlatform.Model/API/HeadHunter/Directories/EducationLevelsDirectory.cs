using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class EducationLevelsDirectory
    {
        [JsonProperty("education_level")]
        public EducationLevel[] EducationLevels { get; set; }
    }

    public class EducationLevelsDirectory<T> where T : EducationLevel
    {
        [JsonProperty("education_level")]
        public T[] EducationLevels { get; set; }
    }
}
