using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Models;
using OnlineRecruitingPlatform.Model.Database;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Controllers
{
    public class VacancyController : Controller
    {
        private readonly DataManager _dataManager;

        public VacancyController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [Route("~/Vacancy/Browse")]
        public IActionResult Browse()
        {
            var numberPage = 1;
            var itemsPerPage = 25;
            var countVacancies = _dataManager.Vacancies.GetCountVacancies();
            var vacancies = _dataManager.Vacancies.GetBrowseVacancies(itemsPerPage, numberPage).ToList();

            var viewModel = new BrowseVacanciesViewModel()
            {
                Vacancies = vacancies,
                NumberPage = numberPage,
                ItemsPerPage = itemsPerPage,
                CountVacancies = countVacancies,
                FirstNumberVacancy = ((numberPage - 1) * itemsPerPage) + 1,
                LastNumberVacancy = countVacancies > numberPage * itemsPerPage ? numberPage * itemsPerPage : countVacancies
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("~/Vacancy/Browse")]
        public IActionResult Browse(BrowseVacanciesViewModel viewModel)
        {
            var numberPage = 1;
            var itemsPerPage = 25;
            var countVacancies = _dataManager.Vacancies.GetCountVacancies(viewModel.SearchStringByJobTitleSkillsOrCompany);
            var vacancies = _dataManager.Vacancies.GetBrowseVacancies(itemsPerPage, numberPage, viewModel.SearchStringByJobTitleSkillsOrCompany).ToList();

            viewModel.Vacancies = vacancies;
            viewModel.NumberPage = numberPage;
            viewModel.ItemsPerPage = itemsPerPage;
            viewModel.CountVacancies = countVacancies;
            viewModel.FirstNumberVacancy = ((numberPage - 1) * itemsPerPage) + 1;
            viewModel.LastNumberVacancy = countVacancies > numberPage * itemsPerPage ? numberPage * itemsPerPage : countVacancies;

            return View(viewModel);
        }

        [HttpGet]
        [Route("~/Vacancy/Browse/page={numberPage}")]
        public IActionResult Browse(int numberPage)
        {
            var itemsPerPage = 25;
            var countVacancies = _dataManager.Vacancies.GetCountVacancies();
            var vacancies = _dataManager.Vacancies.GetBrowseVacancies(itemsPerPage, numberPage).ToList();

            var viewModel = new BrowseVacanciesViewModel()
            {
                Vacancies = vacancies,
                NumberPage = numberPage,
                ItemsPerPage = itemsPerPage,
                CountVacancies = countVacancies,
                FirstNumberVacancy = ((numberPage - 1) * itemsPerPage) + 1,
                LastNumberVacancy = countVacancies > numberPage * itemsPerPage ? numberPage * itemsPerPage : countVacancies
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("~/Vacancy/Browse/{vacancyId}")]
        public IActionResult BrowseVacancy(Guid vacancyId)
        {
            return View();
        }
    }
}
