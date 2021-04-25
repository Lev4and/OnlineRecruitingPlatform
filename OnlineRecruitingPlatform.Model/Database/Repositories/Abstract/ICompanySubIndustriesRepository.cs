using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICompanySubIndustriesRepository
    {
        bool ContainsCompanySubIndustry(Guid companyId, Guid subIndustryId);

        bool SaveCompanySubIndustry(CompanySubIndustry entity);

        CompanySubIndustry GetCompanySubIndustry(Guid id, bool track = false);

        IQueryable<CompanySubIndustry> GetCompanySubIndustries(bool track = false);

        void DeleteCompanySubIndustry(Guid id);
    }
}
