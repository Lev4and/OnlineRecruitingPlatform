using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICompanyRelationsRepository
    {
        bool ContainsCompanyRelation(Guid companyId, Guid relationId);

        bool SaveCompanyRelation(CompanyRelation entity);

        CompanyRelation GetCompanyRelation(Guid id, bool track = false);

        IQueryable<CompanyRelation> GerCompanyRelations(bool track = false);

        void DeleteCompanyRelation(Guid id);
    }
}
