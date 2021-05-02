using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacancyInformationRepository
    {
        bool ContainsVacancyInformation(Guid vacancyId);

        bool SaveVacancyInformation(VacancyInformation entity);

        VacancyInformation GetVacancyInformation(Guid id, bool track = false);

        IQueryable<VacancyInformation> GetVacancyInformation(bool track = false);

        void DeleteVacancyInformation(Guid id);
    }
}