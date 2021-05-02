using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class WorkingTimeModesDirectory
    {
        [JsonProperty("working_time_modes")]
        public WorkingTimeModes[] WorkingTimeModes { get; set; }
    }
}