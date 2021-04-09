using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ILanguageLevelsRepository
    {
        bool ContainsLanguageLevel(string name);

        bool SaveLanguageLevel(LanguageLevel entity);

        LanguageLevel GetLanguageLevel(Guid id, bool track = false);

        LanguageLevel GetLanguageLevel(string name, bool track = false);

        IQueryable<LanguageLevel> GetLanguageLevels();

        void DeleteLanguageLevel(Guid id);
    }
}
