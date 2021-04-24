using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class RegionsDirectory
    {
        [JsonProperty("areas")]
        public RegionIV[] Regions { get; set; }
    }
}
