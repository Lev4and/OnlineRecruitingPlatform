using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacancySalariesRepository
    {
        bool ContainsVacancySalary(Guid vacancyId);

        bool SaveVacancySalary(VacancySalary entity);

        VacancySalary GetVacancySalary(Guid id, bool track = false);

        IQueryable<VacancySalary> GetVacancySalaries(bool track = false);

        void DeleteVacancySalary(Guid id);
    }
}