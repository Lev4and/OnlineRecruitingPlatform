using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class VacancyTypesDirectory
    {
        [JsonProperty("vacancy_type")]
        public VacancyType[] VacancyTypes { get; set; }
    }

    public class VacancyTypesDirectory<T> where T : VacancyType
    {
        [JsonProperty("vacancy_type")]
        public T[] VacancyTypes { get; set; }
    }
}