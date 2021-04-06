using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IEducationLevelsRepository
    {
        bool ContainsEducationLevel(string name);

        bool SaveEducationLevel(EducationLevel entity);

        EducationLevel GetEducationLevel(Guid id, bool track = false);

        EducationLevel GetEducationLevel(string name, bool track = false);

        IQueryable<EducationLevel> GetEducationLevels();

        void DeleteEducationLevel(Guid id);
    }
}
