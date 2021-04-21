using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class EmployerActiveVacanciesOrdersDirectory
    {
        [JsonProperty("employer_active_vacancies_order")]
        public EmployerActiveVacanciesOrder[] EmployerActiveVacanciesOrders { get; set; }
    }

    public class EmployerActiveVacanciesOrdersDirectory<T> where T : EmployerActiveVacanciesOrder
    {
        [JsonProperty("employer_active_vacancies_order")]
        public T[] EmployerActiveVacanciesOrders { get; set; }
    }
}
