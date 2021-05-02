using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class SchedulesDirectory
    {
        [JsonProperty("schedule")]
        public Schedule[] Schedules { get; set; }
    }

    public class SchedulesDirectory<T> where T : Schedule
    {
        [JsonProperty("schedule")]
        public T[] Schedules { get; set; }
    }
}