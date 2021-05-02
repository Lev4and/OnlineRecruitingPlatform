using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacancyKeySkillsRepository
    {
        bool ContainsVacancyKeySkill(Guid vacancyId, Guid skillId);

        bool SaveVacancyKeySkill(VacancyKeySkill entity);

        VacancyKeySkill GetVacancyKeySkill(Guid id, bool track = false);

        VacancyKeySkill GetVacancyKeySkill(Guid vacancyId, Guid skillId, bool track = false);

        IQueryable<VacancyKeySkill> GetVacancyKeySkills(bool track = false);

        void DeleteVacancyKeySkill(Guid id);
    }
}