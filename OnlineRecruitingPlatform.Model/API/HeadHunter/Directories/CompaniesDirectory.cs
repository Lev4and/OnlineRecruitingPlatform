using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class CompaniesDirectory
    {
        [JsonProperty("items")]
        public CompanyIV[] Companies { get; set; }
    }
}
