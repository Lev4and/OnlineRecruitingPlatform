using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacancyVisibilityTypesRepository
    {
        bool ContainsVacancyVisibilityType(string name);

        bool SaveVacancyVisibilityType(VacancyVisibilityType entity);

        VacancyVisibilityType GetVacancyVisibilityType(Guid id, bool track = false);

        VacancyVisibilityType GetVacancyVisibilityType(string name, bool track = false);

        IQueryable<VacancyVisibilityType> GetVacancyVisibilityTypes(bool track = false);

        void DeleteVacancyVisibilityType(Guid id);
    }
}