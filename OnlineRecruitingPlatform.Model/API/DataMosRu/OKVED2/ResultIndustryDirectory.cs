using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.DataMosRu.OKVED2
{
    public class ResultIndustryDirectory
    {
        [JsonProperty("Cells")]
        public IndustryIVDataMosRu Industry { get; set; }
    }
}