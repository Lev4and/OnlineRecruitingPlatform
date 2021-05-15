using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICompanyContactPhonesRepository
    {
        bool ContainsCompanyContactPhone(Guid companyContactId, string phone);

        bool SaveCompanyContactPhone(CompanyContactPhone entity);

        CompanyContactPhone GetCompanyContactPhone(Guid id, bool track = false);

        CompanyContactPhone GetCompanyContactPhone(Guid companyContactId, string phone, bool track = false);

        IQueryable<CompanyContactPhone> GetCompanyContactPhones(bool track = false);

        void DeleteCompanyContactPhone(Guid id);
    }
}
