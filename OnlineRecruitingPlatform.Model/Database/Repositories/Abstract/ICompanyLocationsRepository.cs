using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICompanyLocationsRepository
    {
        bool ContainsCompanyLocation(Guid companyId, Guid areaId);

        bool SaveCompanyLocation(CompanyLocation entity);

        CompanyLocation GetCompanyLocation(Guid id, bool track = false);

        IQueryable<CompanyLocation> GetCompanyLocations(bool track = false);

        void DeleteCompanyLocation(Guid id);
    }
}
