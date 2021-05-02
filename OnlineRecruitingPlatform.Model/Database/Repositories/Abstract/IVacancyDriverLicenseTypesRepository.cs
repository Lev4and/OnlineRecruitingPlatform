using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacancyDriverLicenseTypesRepository
    {
        bool ContainsVacancyDriverLicenseType(Guid vacancyId, Guid driverLicenseTypeId);

        bool SaveVacancyDriverLicenseType(VacancyDriverLicenseType entity);

        VacancyDriverLicenseType GetVacancyDriverLicenseType(Guid id, bool track = false);

        VacancyDriverLicenseType GetVacancyDriverLicenseType(Guid vacancyId, Guid driverLicenseTypeId,
            bool track = false);

        IQueryable<VacancyDriverLicenseType> GetVacancyDriverLicenseTypes(bool track = false);

        void DeleteVacancyDriverLicenseType(Guid id);
    }
}