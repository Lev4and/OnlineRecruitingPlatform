using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Models
{
    public class BrowseVacanciesViewModel
    {
        [Display(Name = "Номер страницы")]
        public int NumberPage { get; set; }

        [Display(Name = "Количество элементов в странице")]
        public int ItemsPerPage { get; set; }

        [Display(Name = "Количество вакансий")]
        public int CountVacancies { get; set; }

        [Display(Name = "Порядковый номер первой вакансии")]
        public int FirstNumberVacancy { get; set; }

        [Display(Name = "Порядковый номер последней вакансии")]
        public int LastNumberVacancy { get; set; }

        [Display(Name = "Строка поиска по городу, адресу или почтовому индексу")]
        public string SearchStringByCityAddressOrZip { get; set; }

        [Display(Name = "Строка поиска по названии вакансий, навыкам или по названию компании")]
        public string SearchStringByJobTitleSkillsOrCompany { get; set; }

        [Display(Name = "Вакансии")]
        public List<Vacancy> Vacancies { get; set; }
    }
}
