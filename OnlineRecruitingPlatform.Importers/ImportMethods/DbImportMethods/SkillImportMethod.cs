using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;

namespace OnlineRecruitingPlatform.Importers.ImportMethods.DbImportMethods
{
    public class SkillImportMethod : DbImportMethod
    {
        public SkillImportMethod(DataManager dataManager) : base(dataManager)
        {

        }

        public override void Save(object entity)
        {
            _dataManager.Skills.SaveSkill((Skill)entity);
        }
    }
}
