using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacanciesRepository
    {
        bool ContainsVacancyByIdentifierFromZarplataRu(int id);

        bool ContainsVacancyByIdentifierFromHeadHunter(int id);

        Vacancy GetVacancy(Guid id, bool track = false);

        Vacancy GetVacancyByIdentifierFromZarplataRu(int id, bool track = false);

        IQueryable<Vacancy> GetVacancies(bool track = false);
        
        void SaveVacancy(Vacancy entity);

        void DeleteVacancy(Guid id);
    }
}