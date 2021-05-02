using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class VacancyBillingTypesDirectory
    {
        [JsonProperty("vacancy_billing_type")]
        public VacancyBillingType[] VacancyBillingTypes { get; set; }
    }

    public class VacancyBillingTypesDirectory<T> where T : VacancyBillingType
    {
        [JsonProperty("vacancy_billing_type")]
        public T[] VacancyBillingTypes { get; set; }
    }
}