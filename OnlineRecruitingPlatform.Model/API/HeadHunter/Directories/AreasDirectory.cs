using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class AreasDirectory
    {
        [JsonProperty("areas")]
        public AreaIV[] Areas { get; set; }
    }
}
