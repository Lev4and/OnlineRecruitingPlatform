using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICompaniesRepository
    {
        bool ContainsCompany(string name);

        bool SaveCompany(Company entity);

        Company GetCompany(Guid id, bool track = false);

        Company GetCompany(string name, bool track = false);

        IQueryable<Company> GetCompanies(bool track = false);

        void DeleteCompany(Guid id);
    }
}
