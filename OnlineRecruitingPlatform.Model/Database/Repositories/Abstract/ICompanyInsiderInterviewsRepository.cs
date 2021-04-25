using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICompanyInsiderInterviewsRepository
    {
        bool ContainsCompanyInsiderInterview(string title);

        bool SaveCompanyInsiderInterview(CompanyInsiderInterview entity);

        CompanyInsiderInterview GetCompanyInsiderInterview(Guid id, bool track = false);

        IQueryable<CompanyInsiderInterview> GetCompanyInsiderInterviews(bool track = false);

        void DeleteCompanyInsiderInterview(Guid id);
    }
}
