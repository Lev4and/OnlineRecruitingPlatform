using Microsoft.AspNetCore.Mvc;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Components
{
    public class BrowseVacanciesHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default");
        }
    }
}