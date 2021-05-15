using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.Model.API.CLADR
{
    public class ResultContent
    {
        [JsonProperty("result")]
        public Content[] Contents { get; set; }
    }
}
