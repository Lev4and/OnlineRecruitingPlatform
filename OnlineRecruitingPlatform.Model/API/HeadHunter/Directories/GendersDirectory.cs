using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class GendersDirectory
    {
        [JsonProperty("gender")]
        public Gender[] Genders { get; set; }
    }

    public class GendersDirectory<T> where T : Gender
    {
        [JsonProperty("gender")]
        public T[] Genders { get; set; }
    }
}
