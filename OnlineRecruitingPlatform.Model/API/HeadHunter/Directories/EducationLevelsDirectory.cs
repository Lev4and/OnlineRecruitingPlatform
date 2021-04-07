using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class EducationLevelsDirectory
    {
        [JsonProperty("education_level")]
        public EducationLevel[] EducationLevels { get; set; }
    }
}
