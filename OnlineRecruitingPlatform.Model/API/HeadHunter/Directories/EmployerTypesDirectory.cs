using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class EmployerTypesDirectory
    {
        [JsonProperty("employer_type")]
        public EmployerType[] EmployerTypes { get; set; }
    }
}
