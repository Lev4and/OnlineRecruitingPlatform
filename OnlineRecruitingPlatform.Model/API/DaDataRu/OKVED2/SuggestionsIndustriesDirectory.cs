using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.DaDataRu.OKVED2
{
    public class SuggestionsIndustriesDirectory
    {
        [JsonProperty("suggestions")]
        public Suggestion<IndustryIV>[] Suggestions { get; set; }
    }
}
