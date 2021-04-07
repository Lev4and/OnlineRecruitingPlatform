using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class EmployerArchivedVacanciesOrdersDirectory
    {
        [JsonProperty("employer_archived_vacancies_order")]
        public EmployerArchivedVacanciesOrder[] EmployerArchivedVacanciesOrders { get; set; }
    }
}
