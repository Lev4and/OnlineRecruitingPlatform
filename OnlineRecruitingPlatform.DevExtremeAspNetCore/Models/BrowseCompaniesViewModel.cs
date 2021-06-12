using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Models
{
    public class BrowseCompaniesViewModel
    {
        [Display(Name = "Номер страницы")]
        public int NumberPage { get; set; }

        [Display(Name = "Количество элементов в странице")]
        public int ItemsPerPage { get; set; }

        [Display(Name = "Количество компаний")]
        public int CountCompanies { get; set; }

        [Display(Name = "Порядковый номер первой компании")]
        public int FirstNumberCompany { get; set; }

        [Display(Name = "Порядковый номер последней компании")]
        public int LastNumberCompany { get; set; }

        [Display(Name = "Строка поиска по названию компании")]
        public string SearchStringByTitle { get; set; }

        [Display(Name = "Строка поиска по расположению компании")]
        public string SearchStringByLocation { get; set; }

        [Display(Name = "Выбранный идентификатор подотрасли компании")]
        public Guid? SelectedSubIndustryId { get; set; }

        [Display(Name = "Список компаний")]
        public List<Company> Companies { get; set; }

        [Display(Name = "Список подотраслей")]
        public List<SubIndustry> SubIndustries { get; set; }
    }
}
