using Microsoft.AspNetCore.Mvc;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Components
{
    public class BrowseResumesHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default");
        }
    }
}
