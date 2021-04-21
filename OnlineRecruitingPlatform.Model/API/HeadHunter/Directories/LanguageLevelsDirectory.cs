using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class LanguageLevelsDirectory
    {
        [JsonProperty("language_level")]
        public LanguageLevel[] LanguageLevels { get; set; }
    }

    public class LanguageLevelsDirectory<T> where T : LanguageLevel
    {
        [JsonProperty("language_level")]
        public T[] LanguageLevels { get; set; }
    }
}
