using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Models;
using OnlineRecruitingPlatform.Model.Database;
using System.Linq;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel()
            {
                CountResume = 0,
                CountApplicants = 0,
                SearchStringByCityAddressOrZip = "",
                SearchStringByJobTitleSkillsOrCompany = "",
                CountCompanies = _dataManager.Companies.GetCountCompanies(),
                CountVacancies = _dataManager.Vacancies.GetCountVacancies(),
                CountActiveVacancies = _dataManager.Vacancies.GetCountAvtiveVacancies(),
                RecentVacancies = _dataManager.Vacancies.GetRecentVacancies(5).ToList()
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
        {
            return View();
        }
    }
}
