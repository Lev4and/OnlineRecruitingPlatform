using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.DataMosRu.OKVED2
{
    public class ResultSubIndustryDirectory
    {
        [JsonProperty("Cells")]
        public SubIndustryIVDataMosRu SubIndustry { get; set; }
    }
}