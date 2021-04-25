using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICompanyInformationRepository
    {
        bool ContainsCompanyInformation(Guid companyId);

        bool SaveCompanyInformation(CompanyInformation entity);

        CompanyInformation GetCompanyInformation(Guid id, bool track = false);

        IQueryable<CompanyInformation> GetCompanyInformation(bool track = false);

        void DeleteCompanyInformation(Guid id);
    }
}
