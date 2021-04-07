using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class GendersDirectory
    {
        [JsonProperty("gender")]
        public Gender[] Genders { get; set; }
    }
}
