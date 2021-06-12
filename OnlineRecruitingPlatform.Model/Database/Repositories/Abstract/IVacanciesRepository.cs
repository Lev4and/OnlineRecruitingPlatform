using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacanciesRepository
    {
        bool ContainsVacancyByIdentifierFromZarplataRu(int id);

        bool ContainsVacancyByIdentifierFromHeadHunter(int id);

        int GetCountVacancies();

        int GetCountVacancies(string searchStringByJobTitleSkillsOrCompany = "");

        int GetCountAvtiveVacancies();

        Vacancy GetVacancy(Guid id, bool track = false);

        Vacancy GetVacancyByIdentifierFromZarplataRu(int id, bool track = false);

        IQueryable<Vacancy> GetVacancies(bool track = false);

        IQueryable<Vacancy> GetBrowseVacancies(int itemsPerPage = 5, int numberPage = 1, string searchStringByJobTitleSkillsOrCompany = "", bool track = false);

        IQueryable<Vacancy> GetRecentVacancies(int itemsInResult, bool track = false);
        
        void SaveVacancy(Vacancy entity);

        void DeleteVacancy(Guid id);
    }
}