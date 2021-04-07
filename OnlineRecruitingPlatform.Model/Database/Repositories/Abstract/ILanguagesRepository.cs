using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ILanguagesRepository
    {
        bool ContainsLanguage(string name);

        bool SaveLanguage(Language entity);

        Language GetLanguage(Guid id, bool track = false);

        Language GetLanguage(string name, bool track = false);

        IQueryable<Language> GetLanguages();

        void DeleteLanguage(Guid id);
    }
}
