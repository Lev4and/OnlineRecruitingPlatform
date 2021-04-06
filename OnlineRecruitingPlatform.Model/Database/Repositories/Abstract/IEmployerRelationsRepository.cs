using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IEmployerRelationsRepository
    {
        bool ContainsEmployerRelation(string name);

        bool SaveEmployerRelation(EmployerRelation entity);

        EmployerRelation GetEmployerRelation(Guid id, bool track = false);

        EmployerRelation GetEmployerRelation(string name, bool track = false);

        IQueryable<EmployerRelation> GetEmployerRelations();

        void DeleteEmployerRelation(Guid id);
    }
}
