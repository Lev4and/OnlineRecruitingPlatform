using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacancyTypesRepository
    {
        bool ContainsVacancyType(string name);

        bool SaveVacancyType(VacancyType entity);

        VacancyType GetVacancyType(Guid id, bool track = false);

        VacancyType GetVacancyType(string name, bool track = false);

        VacancyType GetVacancyTypeByIdentifierFromHeadHunter(string id, bool track = false);

        IQueryable<VacancyType> GetVacancyTypes(bool track = false);

        void DeleteVacancyType(Guid id);
    }
}