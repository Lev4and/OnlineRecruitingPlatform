using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class EmployerArchivedVacanciesOrdersDirectory
    {
        [JsonProperty("employer_archived_vacancies_order")]
        public EmployerArchivedVacanciesOrder[] EmployerArchivedVacanciesOrders { get; set; }
    }

    public class EmployerArchivedVacanciesOrdersDirectory<T> where T : EmployerArchivedVacanciesOrder
    {
        [JsonProperty("employer_archived_vacancies_order")]
        public T[] EmployerArchivedVacanciesOrders { get; set; }
    }
}
