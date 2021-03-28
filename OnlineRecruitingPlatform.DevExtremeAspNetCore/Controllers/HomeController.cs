using Microsoft.AspNetCore.Mvc;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("�������������"))
                {
                    return Redirect("~/Admin/Home/Index/");
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
        {
            return View();
        }
    }
}
