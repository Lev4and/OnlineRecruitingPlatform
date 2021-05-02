using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacancyBillingTypesRepository
    {
        bool ContainsVacancyBillingType(string name);

        bool SaveVacancyBillingType(VacancyBillingType entity);

        VacancyBillingType GetVacancyBillingType(Guid id, bool track = false);

        VacancyBillingType GetVacancyBillingType(string name, bool track = false);

        IQueryable<VacancyBillingType> GetVacancyBillingTypes(bool track = false);

        void DeleteVacancyBillingType(Guid id);
    }
}