using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class WorkingDaysDirectory
    {
        [JsonProperty("working_days")]
        public WorkingDays[] WorkingDays { get; set; }
    }

    public class WorkingDaysDirectory<T> where T : WorkingDays
    {
        [JsonProperty("working_days")]
        public T[] WorkingDays { get; set; }
    }
}