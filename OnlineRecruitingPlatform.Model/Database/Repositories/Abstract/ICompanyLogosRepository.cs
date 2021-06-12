using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICompanyLogosRepository
    {
        bool ContainsCompanyLogo(Guid companyId);

        bool SaveCompanyLogo(CompanyLogo entity);

        int GetCountCompanyLogos();

        CompanyLogo GetCompanyLogo(Guid id, bool track = false);

        IQueryable<CompanyLogo> GetCompanyLogos(bool track = false);

        IQueryable<CompanyLogo> GetCompanyLogos(int itemsPerPage, int numberPage, bool track = false);

        void DeleteCompanyLogo(Guid id);
    }
}
