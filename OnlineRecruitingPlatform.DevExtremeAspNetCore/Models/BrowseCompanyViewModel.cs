using OnlineRecruitingPlatform.Model.Database.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Models
{
    public class BrowseCompanyViewModel
    {
        [Display(Name = "Компания")]
        public Company Company { get; set; }
    }
}
