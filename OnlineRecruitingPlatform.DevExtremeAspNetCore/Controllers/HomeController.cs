using Microsoft.AspNetCore.Mvc;

namespace OnlineRecruitingPlatform_DevExtremeAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Администратор"))
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
