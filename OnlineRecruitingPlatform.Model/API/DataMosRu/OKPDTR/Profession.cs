using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.DataMosRu.OKPDTR
{
    public class Profession
    {
        [JsonProperty("Cells")]
        public ProfessionIV Content { get; set; }
    }
}
