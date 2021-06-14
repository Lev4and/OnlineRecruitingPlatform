using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Models;
using OnlineRecruitingPlatform.Model.Deserializers;
using System.Linq;
using System.Threading.Tasks;
using HeadHunterClients = OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients;
using HeadHunterCompanies = OnlineRecruitingPlatform.Model.API.HeadHunter.Companies;
using ZarplataRu = OnlineRecruitingPlatform.Model.API.ZarplataRu;
using ZarplataRuClients = OnlineRecruitingPlatform.HttpClients.ZarplataRu.Clients;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Controllers
{
    public class CompanyController : Controller
    {
        private readonly HeadHunterClients.Companies.CompaniesClient _companiesHeadHunterClient;
        private readonly ZarplataRuClients.Companies.CompaniesClient _companiesZarplataRuClient;

        public CompanyController(HeadHunterClients.Companies.CompaniesClient companiesHeadHunterClient, ZarplataRuClients.Companies.CompaniesClient companiesZarplataRuClient)
        {
            _companiesHeadHunterClient = companiesHeadHunterClient;
            _companiesZarplataRuClient = companiesZarplataRuClient;
        }

        [Route("~/Company")]
        [Route("~/Company/Browse")]
        public async Task<IActionResult> Browse()
        {
            var resultCompaniesHeadHunter = await BaseDeserializer.Deserialize<HeadHunterCompanies.SearchResultCompanies>(await _companiesHeadHunterClient.GetCompanies(1, 25));
            var resultCompaniesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.CompaniesDirectory>(await _companiesZarplataRuClient.GetCompanies(25, 1));

            var viewModel = new BrowseCompaniesViewModel()
            {
                SearchStringByTitle = "",
                SearchStringByLocation = "",
                CompaniesHeadHunter = resultCompaniesHeadHunter.Companies.ToList(),
                CompaniesZarplataRu = resultCompaniesZarplataRu.Companies.ToList()
            };

            return View(viewModel);
        }

        [Route("~/Company/{type}/{id}")]
        public async Task<IActionResult> Details(string type, int id)
        {
            if (type == "HeadHunter")
            {
                return View("DetailsCompanyHeadHunter", await BaseDeserializer.Deserialize<dynamic>(await _companiesHeadHunterClient.GetCompany(id)));
            }

            if (type == "ZarplataRu")
            {
                var result = await GzipDeserializer.Deserialize<dynamic>(await _companiesZarplataRuClient.GetCompany(id));

                return View("DetailsCompanyZarplataRu", result.companies[0]);
            }

            return View("DetailsCompany");
        }
    }
}
