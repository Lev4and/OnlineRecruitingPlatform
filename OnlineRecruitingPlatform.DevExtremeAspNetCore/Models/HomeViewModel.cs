using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Models
{
    public class HomeViewModel
    {
        [Display(Name = "Количество резюме")]
        public int CountResume { get; set; }

        [Display(Name = "Количество компаний")]
        public int CountCompanies { get; set; }

        [Display(Name = "Количество вакансий")]
        public int CountVacancies { get; set; }

        [Display(Name = "Количество соискателей")]
        public int CountApplicants { get; set; }

        [Display(Name = "Количество активных вакансий")]
        public int CountActiveVacancies { get; set; }

        [Display(Name = "Строка поиска по городу, адресу или почтовому индексу")]
        public string SearchStringByCityAddressOrZip { get; set; }

        [Display(Name = "Строка поиска по названии вакансий, навыкам или по названию компании")]
        public string SearchStringByJobTitleSkillsOrCompany { get; set; }

        public List<dynamic> RecentVacanciesHeadHunter { get; set; }

        public List<dynamic> RecentVacanciesZarplataRu { get; set; }
    }
}
