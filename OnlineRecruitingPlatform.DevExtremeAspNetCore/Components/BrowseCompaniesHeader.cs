using Microsoft.AspNetCore.Mvc;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Components
{
    public class BrowseCompaniesHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default");
        }
    }
}
