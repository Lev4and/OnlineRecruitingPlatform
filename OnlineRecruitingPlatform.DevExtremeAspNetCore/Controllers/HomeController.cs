using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Models;
using OnlineRecruitingPlatform.Model.Deserializers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HeadHunterClients = OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients;
using HeadHunterCompanies = OnlineRecruitingPlatform.Model.API.HeadHunter.Companies;
using HeadHunterVacancies = OnlineRecruitingPlatform.Model.API.HeadHunter.Vacancies;
using ZarplataRu = OnlineRecruitingPlatform.Model.API.ZarplataRu;
using ZarplataRuClients = OnlineRecruitingPlatform.HttpClients.ZarplataRu.Clients;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly HeadHunterClients.Resumes.ResumesClient _resumesHeadHunterClient;
        private readonly ZarplataRuClients.Resumes.ResumesClient _resumesZarplataRuClient;
        private readonly HeadHunterClients.Companies.CompaniesClient _companiesHeadHunterClient;
        private readonly ZarplataRuClients.Companies.CompaniesClient _companiesZarplataRuClient;
        private readonly HeadHunterClients.Vacancies.VacanciesClient _vacanciesHeadHunterClient;
        private readonly ZarplataRuClients.Vacancies.VacanciesClient _vacanciesZarplataRuClient;

        public HomeController(HeadHunterClients.Resumes.ResumesClient resumesHeadHunterClient, ZarplataRuClients.Resumes.ResumesClient resumesZarplataRuClient, HeadHunterClients.Companies.CompaniesClient companiesHeadHunterClient, ZarplataRuClients.Companies.CompaniesClient companiesZarplataRuClient, HeadHunterClients.Vacancies.VacanciesClient vacanciesHeadHunterClient, ZarplataRuClients.Vacancies.VacanciesClient vacanciesZarplataRuClient)
        {
            _resumesHeadHunterClient = resumesHeadHunterClient;
            _resumesZarplataRuClient = resumesZarplataRuClient;
            _companiesHeadHunterClient = companiesHeadHunterClient;
            _companiesZarplataRuClient = companiesZarplataRuClient;
            _vacanciesHeadHunterClient = vacanciesHeadHunterClient;
            _vacanciesZarplataRuClient = vacanciesZarplataRuClient;
        }
        
        public async Task<IActionResult> Index()
        {
            var countResumes = 0;
            var countCompanies = 0;
            var countVacancies = 0;
            var countActiveVacancies = 0;
            var recentVacanciesHeadHunter = new List<dynamic>();
            var recentVacanciesZarplataRu = new List<dynamic>();

            //var resultCountHeadHunterResumes = await BaseDeserializer.Deserialize<HeadHunterResumes.ResumesDirectory>(await _resumesHeadHunterClient.GetResumes(1, 1));
            var resultCountZarplataRuResumes = await GzipDeserializer.Deserialize<ZarplataRu.ResumesDirectory>(await _resumesZarplataRuClient.GetResumes(0, 0));

            //countResumes += resultCountHeadHunterResumes.Found;
            countResumes += resultCountZarplataRuResumes.Metadata.Resultset.Count;

            var resultCountCompaniesHeadHunter = await BaseDeserializer.Deserialize<HeadHunterCompanies.SearchResultCompanies>(await _companiesHeadHunterClient.GetCompanies(1, 1));
            var resultCountCompaniesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.CompaniesDirectory>(await _companiesZarplataRuClient.GetCompanies(0, 0));

            countCompanies += resultCountCompaniesHeadHunter.Found;
            countCompanies += resultCountCompaniesZarplataRu.Metadata.Resultset.Count;

            var resultCountVacanciesHeadHunter = await BaseDeserializer.Deserialize<HeadHunterCompanies.SearchResultCompanies>(await _vacanciesHeadHunterClient.GetVacancies(new DateTime(2000, 1, 1, 0, 0, 0), DateTime.Now, 1, 1));
            var resultCountVacanciesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.VacanciesDirectory>(await _vacanciesZarplataRuClient.GetVacancies(1, 1));

            countVacancies += resultCountVacanciesHeadHunter.Found;
            countVacancies += resultCountVacanciesZarplataRu.Metadata.Resultset.Count;

            var resultCountActiveVacanciesHeadHunter = await BaseDeserializer.Deserialize<HeadHunterVacancies.VacanciesDirectory>(await _vacanciesHeadHunterClient.GetActiveVacancies(new DateTime(2000, 1, 1, 0, 0, 0), DateTime.Now, 1, 1));
            var resultCountActiveVacanciesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.VacanciesDirectory>(await _vacanciesZarplataRuClient.GetNewVacancies(10, 0));

            countActiveVacancies += resultCountActiveVacanciesHeadHunter.Found;
            countActiveVacancies += resultCountActiveVacanciesZarplataRu.Metadata.Resultset.Count;

            var resultRecentVacanciesHeadHunter = await BaseDeserializer.Deserialize<HeadHunterVacancies.VacanciesDirectory>(await _vacanciesHeadHunterClient.GetActiveVacancies(DateTime.Now.AddDays(-1), DateTime.Now, 10, 1));
            var resultRecentVacanciesZarplataRu = await GzipDeserializer.Deserialize<ZarplataRu.VacanciesDirectory>(await _vacanciesZarplataRuClient.GetNewVacancies(10, 0));

            recentVacanciesHeadHunter.AddRange(resultRecentVacanciesHeadHunter.Vacancies);
            recentVacanciesZarplataRu.AddRange(resultRecentVacanciesZarplataRu.Vacancies);

            var viewModel = new HomeViewModel()
            {
                CountResume = countResumes,
                CountCompanies = countCompanies,
                CountVacancies = countVacancies,
                SearchStringByCityAddressOrZip = "",
                SearchStringByJobTitleSkillsOrCompany = "",
                CountActiveVacancies = countActiveVacancies,
                RecentVacanciesHeadHunter = recentVacanciesHeadHunter,
                RecentVacanciesZarplataRu = recentVacanciesZarplataRu
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
