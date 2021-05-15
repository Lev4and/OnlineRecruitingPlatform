using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICompanyContactsRepository
    {
        bool ContainsCompanyContact(Guid companyId, Guid addressId);

        bool SaveCompanyContact(CompanyContact entity);

        CompanyContact GetCompanyContact(Guid id, bool track = false);

        CompanyContact GetCompanyContact(Guid companyId, Guid addressId, bool track = false);

        IQueryable<CompanyContact> GetCompanyContacts(bool track = false);

        void DeleteCompanyContact(Guid id);
    }
}
