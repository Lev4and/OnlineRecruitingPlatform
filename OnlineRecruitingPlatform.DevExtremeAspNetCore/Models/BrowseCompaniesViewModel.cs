using System.Collections.Generic;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Models
{
    public class BrowseCompaniesViewModel
    {
        public string SearchStringByTitle { get; set; }

        public string SearchStringByLocation { get; set; }

        public List<dynamic> CompaniesHeadHunter { get; set; }

        public List<dynamic> CompaniesZarplataRu { get; set; }
    }
}
