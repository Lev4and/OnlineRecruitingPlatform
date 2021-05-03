using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IAgePreferencesRepository
    {
        bool ContainsAgePreference(string name);

        bool SaveAgePreference(AgePreference entity);

        AgePreference GetAgePreference(Guid id, bool track = false);

        AgePreference GetAgePreference(string name, bool track = false);

        IQueryable<AgePreference> GetAgePreferences(bool track = false);

        void DeleteAgePreference(Guid id);
    }
}
