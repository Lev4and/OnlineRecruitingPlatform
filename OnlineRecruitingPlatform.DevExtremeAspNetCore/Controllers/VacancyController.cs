using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Models;
using OnlineRecruitingPlatform.Model.Deserializers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadHunterClients = OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients;
using HeadHunterVacancies = OnlineRecruitingPlatform.Model.API.HeadHunter.Vacancies;
using ZarplataRu = OnlineRecruitingPlatform.Model.API.ZarplataRu;
using ZarplataRuClients = OnlineRecruitingPlatform.HttpClients.ZarplataRu.Clients;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Controllers
{
    public class VacancyController : Controller
    {
        private readonly HeadHunterClients.Vacancies.VacanciesClient _vacanciesHeadHunterClient;
        private readonly ZarplataRuClients.Vacancies.VacanciesClient _vacanciesZarplataRuClient;

        public VacancyController(HeadHunterClients.Vacancies.VacanciesClient vacanciesHeadHunterClient, ZarplataRuClients.Vacancies.VacanciesClient vacanciesZarplataRuClient)
        {
            _vacanciesHeadHunterClient = vacanciesHeadHunterClient;
            _vacanciesZarplataRuClient = vacanciesZarplataRuClient;
        }

        [Route("~/Vacancy")]
        [Route("~/Vacancy/Browse")]
        public async Task<IActionResult> Browse()
        {
            var resultVacanciesHeadHunter = await BaseDeserializer.Deserialize<HeadHunterVacancies.VacanciesDirectory>(await _vacanciesHeadHunterClient.GetVacancies(25, 1));
            var resultVacanciesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.VacanciesDirectory>(await _vacanciesZarplataRuClient.GetVacancies(25, 1));

            var viewModel = new BrowseVacanciesViewModel()
            {
                NumberPage = 1,
                SearchStringByCityAddressOrZip = "",
                SearchStringByJobTitleSkillsOrCompany = "",
                VacanciesHeadHunter = resultVacanciesHeadHunter.Vacancies.ToList(),
                VacanciesZarplataRu = resultVacanciesZarplataRu.Vacancies.ToList(),
                CountItems = resultVacanciesHeadHunter.Found + resultVacanciesZarplataRu.Metadata.Resultset.Count
            };

            viewModel.GeneratePagination();

            return View(viewModel);
        }

        [Route("~/Vacancy/Browse/{title}")]
        public async Task<IActionResult> Browse(string title)
        {
            var resultVacanciesHeadHunter = await BaseDeserializer.Deserialize<HeadHunterVacancies.VacanciesDirectory>(await _vacanciesHeadHunterClient.GetVacancies(25, 1, title));
            var resultVacanciesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.VacanciesDirectory>(await _vacanciesZarplataRuClient.GetVacancies(25, 1, title));

            var viewModel = new BrowseVacanciesViewModel()
            {
                NumberPage = 1,
                SearchStringByCityAddressOrZip = "",
                SearchStringByJobTitleSkillsOrCompany = title,
                VacanciesHeadHunter = resultVacanciesHeadHunter.Vacancies.ToList(),
                VacanciesZarplataRu = resultVacanciesZarplataRu.Vacancies.ToList(),
                CountItems = resultVacanciesHeadHunter.Found + resultVacanciesZarplataRu.Metadata.Resultset.Count
            };

            viewModel.GeneratePagination();

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Vacancy/Browse")]
        public async Task<IActionResult> Browse(BrowseVacanciesViewModel viewModel)
        {
            var resultVacanciesHeadHunter = await BaseDeserializer.Deserialize<HeadHunterVacancies.VacanciesDirectory>(await _vacanciesHeadHunterClient.GetVacancies(25, viewModel.NumberPage, viewModel.SearchStringByJobTitleSkillsOrCompany, viewModel.SearchStringByCityAddressOrZip));
            var resultVacanciesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.VacanciesDirectory>(await _vacanciesZarplataRuClient.GetVacancies(25, viewModel.NumberPage * 25, viewModel.SearchStringByJobTitleSkillsOrCompany, viewModel.SearchStringByCityAddressOrZip));

            if(resultVacanciesHeadHunter == null)
            {
                resultVacanciesHeadHunter = new HeadHunterVacancies.VacanciesDirectory()
                {
                    Found = 0,
                    Vacancies = new List<dynamic>().ToArray()
                };
            }

            if (resultVacanciesZarplataRu == null)
            {
                resultVacanciesZarplataRu = new ZarplataRu.VacanciesDirectory()
                {
                    Metadata = new ZarplataRu.Metadata()
                    {
                        Resultset = new ZarplataRu.Resultset()
                        {
                            Count = 0
                        }
                    },
                    Vacancies = new List<dynamic>().ToArray()
                };
            }

            viewModel.VacanciesHeadHunter = resultVacanciesHeadHunter.Vacancies.ToList();
            viewModel.VacanciesZarplataRu = resultVacanciesZarplataRu.Vacancies.ToList();
            viewModel.CountItems = resultVacanciesHeadHunter.Found + resultVacanciesZarplataRu.Metadata.Resultset.Count;
            viewModel.GeneratePagination();

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Vacancy")]
        public async Task<IActionResult> Browse(HomeViewModel homeViewModel)
        {
            var resultVacanciesHeadHunter = await BaseDeserializer.Deserialize<HeadHunterVacancies.VacanciesDirectory>(await _vacanciesHeadHunterClient.GetVacancies(25, 1, homeViewModel.SearchStringByJobTitleSkillsOrCompany));
            var resultVacanciesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.VacanciesDirectory>(await _vacanciesZarplataRuClient.GetVacancies(25, 1, homeViewModel.SearchStringByJobTitleSkillsOrCompany));

            var viewModel = new BrowseVacanciesViewModel()
            {
                NumberPage = 1,
                VacanciesHeadHunter = resultVacanciesHeadHunter.Vacancies.ToList(),
                VacanciesZarplataRu = resultVacanciesZarplataRu.Vacancies.ToList(),
                SearchStringByCityAddressOrZip = homeViewModel.SearchStringByCityAddressOrZip,
                SearchStringByJobTitleSkillsOrCompany = homeViewModel.SearchStringByJobTitleSkillsOrCompany,
                CountItems = resultVacanciesHeadHunter.Found + resultVacanciesZarplataRu.Metadata.Resultset.Count
            };

            viewModel.GeneratePagination();

            return View(viewModel);
        }

        [Route("~/Vacancy/{type}/{id}")]
        public async Task<IActionResult> Details(string type, int id)
        {
            if(type == "HeadHunter")
            {
                return View("DetailsVacancyHeadHunter", await BaseDeserializer.Deserialize<dynamic>(await _vacanciesHeadHunterClient.GetVacancy(id)));
            }

            if(type == "ZarplataRu")
            {
                var result = await GzipDeserializer.Deserialize<dynamic>(await _vacanciesZarplataRuClient.GetVacancy(id));

                return View("DetailsVacancyZarplataRu", result.vacancies[0]);
            }

            return View("DetailsVacancy");
        }
    }
}
