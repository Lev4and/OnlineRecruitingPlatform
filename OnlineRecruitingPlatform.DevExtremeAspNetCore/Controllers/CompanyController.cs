using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Models;
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
        
        [Route("~/Company/Browse")]
        public IActionResult Browse()
        {
            var numberPage = 1;
            var itemsPerPage = 25;
            var countCompanies = _dataManager.Companies.GetCountCompanies();
            var companies = _dataManager.Companies.GetBrowseCompanies(itemsPerPage, numberPage).ToList();

            var viewModel = new BrowseCompaniesViewModel()
            {
                Companies = companies,
                NumberPage = numberPage,
                SearchStringByTitle = "",
                ItemsPerPage = itemsPerPage,
                SearchStringByLocation = "",
                SelectedSubIndustryId = null,
                CountCompanies = countCompanies,
                FirstNumberCompany = ((numberPage - 1) * itemsPerPage) + 1,
                SubIndustries = _dataManager.SubIndustries.GetSubIndustries().ToList(),
                LastNumberCompany = countCompanies > numberPage * itemsPerPage ? numberPage * itemsPerPage : countCompanies
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("~/Company/Browse/page={numberPage}")]
        public IActionResult Browse(int numberPage)
        {
            var itemsPerPage = 25;
            var countCompanies = _dataManager.Companies.GetCountCompanies();
            var companies = _dataManager.Companies.GetBrowseCompanies(itemsPerPage, numberPage).ToList();

            var viewModel = new BrowseCompaniesViewModel()
            {
                Companies = companies,
                NumberPage = numberPage,
                SearchStringByTitle = "",
                ItemsPerPage = itemsPerPage,
                SearchStringByLocation = "",
                SelectedSubIndustryId = null,
                CountCompanies = countCompanies,
                FirstNumberCompany = ((numberPage - 1) * itemsPerPage) + 1,
                SubIndustries = _dataManager.SubIndustries.GetSubIndustries().ToList(),
                LastNumberCompany = countCompanies > numberPage * itemsPerPage ? numberPage * itemsPerPage : countCompanies
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("~/Company/Browse/{companyId}")]
        public IActionResult BrowseCompany(Guid companyId)
        {
            return View(new BrowseCompanyViewModel() { Company = _dataManager.Companies.GetCompany(companyId) });
        }
    }
}
