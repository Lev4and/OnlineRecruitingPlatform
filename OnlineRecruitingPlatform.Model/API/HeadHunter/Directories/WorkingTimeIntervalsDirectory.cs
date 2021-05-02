using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class WorkingTimeIntervalsDirectory
    {
        [JsonProperty("working_time_intervals")]
        public WorkingTimeIntervals[] WorkingTimeIntervals { get; set; }
    }

    public class WorkingTimeIntervalsDirectory<T> where T : WorkingTimeIntervals
    {
        [JsonProperty("working_time_intervals")]
        public T[] WorkingTimeIntervals { get; set; }
    }
}