using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacancyRelationsRepository
    {
        bool ContainsVacancyRelation(string name);

        bool SaveVacancyRelation(VacancyRelation entity);

        VacancyRelation GetVacancyRelation(Guid id, bool track = false);

        VacancyRelation GetVacancyRelation(string name, bool track = false);

        IQueryable<VacancyRelation> GetVacancyRelations(bool track = false);

        void DeleteVacancyRelation(Guid id);
    }
}