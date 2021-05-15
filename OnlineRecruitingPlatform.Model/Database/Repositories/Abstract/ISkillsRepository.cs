using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ISkillsRepository
    {
        bool ContainsSkill(string name);

        bool ContainsSkillByIdentifierFromHeadHunter(int id);

        bool SaveSkill(Skill entity);

        Skill GetSkill(Guid id, bool track = false);

        Skill GetSkill(string name, bool track = false);

        Skill GetSkillByIdentifierFromHeadHunter(int id, bool track = false);

        IQueryable<Skill> GetSkills();

        void DeleteSkill(Guid id);
    }
}
