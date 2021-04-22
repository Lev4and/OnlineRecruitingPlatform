using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.Model.API.DaDataRu.OKVED2
{
    public class Suggestion<T> where T : class
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
