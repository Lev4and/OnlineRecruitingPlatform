using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.Model.Database;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Controllers
{
    public class CompanyController : Controller
    {
        private readonly DataManager _dataManager;

        public CompanyController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [Route("~/Company")]
        [Route("~/Company/Browse")]
        public IActionResult Browse()
        {
            ViewBag.companies = _dataManager.Companies.GetBrowseCompanies().ToList();

            return View();
        }

        [HttpGet]
        [Route("~/Company/Browse/{companyId}")]
        public IActionResult BrowseCompany(Guid companyId)
        {
            ViewBag.companies = _dataManager.Companies.GetCompany(companyId);

            return View();
        }
    }
}
