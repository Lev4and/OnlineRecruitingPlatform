using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class SkillsDirectory
    {
        [JsonProperty("items")]
        public Skill[] Skills { get; set; }
    }

    public class SkillsDirectory<T> where T : Skill
    {
        [JsonProperty("items")]
        public T[] Skills { get; set; }
    }
}
