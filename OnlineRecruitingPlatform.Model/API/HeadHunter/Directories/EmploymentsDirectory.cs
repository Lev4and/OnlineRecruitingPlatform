using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class EmploymentsDirectory
    {
        [JsonProperty("employment")]
        public Employment[] Employments { get; set; }
    }

    public class EmploymentsDirectory<T> where T : Employment
    {
        [JsonProperty("employment")]
        public T[] Employments { get; set; }
    }
}
