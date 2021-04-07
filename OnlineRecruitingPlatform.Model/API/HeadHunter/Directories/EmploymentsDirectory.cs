using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class EmploymentsDirectory
    {
        [JsonProperty("employment")]
        public Employment[] Employments { get; set; }
    }
}
