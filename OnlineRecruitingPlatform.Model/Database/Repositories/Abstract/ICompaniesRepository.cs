using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICompaniesRepository
    {
        bool ContainsCompany(string name);

        bool ContainsCompanyByIdentifierFromZarplataRu(int id);

        bool ContainsCompanyByIdentifierFromHeadHunter(int id);

        bool SaveCompany(Company entity);

        Company GetCompany(Guid id, bool track = false);

        Company GetCompany(string name, bool track = false);

        Company GetCompanyByIdentifierFromZarplataRu(int id, bool track = false);

        Company GetCompanyByIdentifierFromHeadHunter(int id, bool track = false);

        IQueryable<Company> GetCompanies(bool track = false);

        IQueryable<Company> GetBrowseCompanies(bool track = false);

        void DeleteCompany(Guid id);

        void DetachCompany(Company entity);
    }
}
