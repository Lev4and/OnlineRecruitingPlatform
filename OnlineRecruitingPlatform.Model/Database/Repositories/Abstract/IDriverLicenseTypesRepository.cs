using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IDriverLicenseTypesRepository
    {
        bool ContainsDriverLicenseType(string name);

        bool SaveDriverLicenseType(DriverLicenseType entity);

        DriverLicenseType GetDriverLicenseType(Guid id, bool track = false);

        DriverLicenseType GetDriverLicenseType(string name, bool track = false);

        IQueryable<DriverLicenseType> GetDriverLicenseTypes();

        void DeleteDriverLicenseType(Guid id);
    }
}
