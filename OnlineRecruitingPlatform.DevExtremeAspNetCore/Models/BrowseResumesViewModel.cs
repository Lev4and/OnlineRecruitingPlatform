using System.Collections.Generic;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Models
{
    public class BrowseResumesViewModel
    {
        public string SearchStringByCityAddressOrZip { get; set; }

        public string SearchStringByJobTitleSkills { get; set; }

        public List<dynamic> ResumesZarplataRu { get; set; }
    }
}
