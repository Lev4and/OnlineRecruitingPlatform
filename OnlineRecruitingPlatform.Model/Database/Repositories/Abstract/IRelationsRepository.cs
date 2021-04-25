using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IRelationsRepository
    {
        bool ContainsRelation(string name);

        bool SaveRelation(Relation entity);

        Relation GetRelation(Guid id, bool track = false);

        Relation GetRelation(string name, bool track = false);

        IQueryable<Relation> GetQueryable(bool track = false);

        void DeleteRelation(Guid id);
    }
}
