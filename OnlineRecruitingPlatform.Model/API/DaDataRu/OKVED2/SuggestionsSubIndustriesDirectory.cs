using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.DaDataRu.OKVED2
{
    public class SuggestionsSubIndustriesDirectory
    {
        [JsonProperty("suggestions")]
        public Suggestion<SubIndustryIV>[] Suggestions { get; set; }
    }
}
