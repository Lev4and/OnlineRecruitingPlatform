using System.Collections.Generic;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Models
{
    public class BrowseVacanciesViewModel
    {
        public string SearchStringByCityAddressOrZip { get; set; }

        public string SearchStringByJobTitleSkillsOrCompany { get; set; }

        public List<dynamic> VacanciesHeadHunter { get; set; }

        public List<dynamic> VacanciesZarplataRu { get; set; }
    }
}
