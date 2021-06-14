using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Models;
using OnlineRecruitingPlatform.Model.Deserializers;
using System.Collections.Generic;
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
                NumberPage = 1,
                SearchStringByTitle = "",
                SearchStringByLocation = "",
                CompaniesHeadHunter = resultCompaniesHeadHunter.Companies.ToList(),
                CompaniesZarplataRu = resultCompaniesZarplataRu.Companies.ToList(),
                CountItems = resultCompaniesHeadHunter.Found + resultCompaniesZarplataRu.Metadata.Resultset.Count
            };

            viewModel.GeneratePagination();

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Company/Browse")]
        public async Task<IActionResult> Browse(BrowseCompaniesViewModel viewModel)
        {
            var resultCompaniesHeadHunter = await BaseDeserializer.Deserialize<HeadHunterCompanies.SearchResultCompanies>(await _companiesHeadHunterClient.GetCompanies(viewModel.NumberPage, 25, viewModel.SearchStringByTitle));
            var resultCompaniesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.CompaniesDirectory>(await _companiesZarplataRuClient.GetCompanies(25, viewModel.NumberPage * 25, viewModel.SearchStringByTitle));

            if (resultCompaniesHeadHunter == null)
            {
                resultCompaniesHeadHunter = new HeadHunterCompanies.SearchResultCompanies()
                {
                    Found = 0,
                    Companies = new List<dynamic>().ToArray()
                };
            }

            if (resultCompaniesZarplataRu == null)
            {
                resultCompaniesZarplataRu = new ZarplataRu.CompaniesDirectory()
                {
                    Metadata = new ZarplataRu.Metadata()
                    {
                        Resultset = new ZarplataRu.Resultset()
                        {
                            Count = 0
                        }
                    },
                    Companies = new List<dynamic>().ToArray()
                };
            }

            viewModel.CompaniesHeadHunter = resultCompaniesHeadHunter.Companies.ToList();
            viewModel.CompaniesZarplataRu = resultCompaniesZarplataRu.Companies.ToList();
            viewModel.CountItems = resultCompaniesHeadHunter.Found + resultCompaniesZarplataRu.Metadata.Resultset.Count;
            viewModel.GeneratePagination();

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
