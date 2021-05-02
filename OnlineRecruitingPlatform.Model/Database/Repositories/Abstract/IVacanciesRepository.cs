using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacanciesRepository
    {
        Vacancy GetVacancy(Guid id, bool track = false);
        
        IQueryable<Vacancy> GetVacancies(bool track = false);
        
        void SaveVacancy(Vacancy entity);

        void DeleteVacancy(Guid id);
    }
}