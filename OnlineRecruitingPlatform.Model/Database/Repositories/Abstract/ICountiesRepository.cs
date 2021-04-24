using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICountiesRepository
    {
        bool ContainsCountry(string name);

        bool SaveCountry(Country entity);

        Country GetCountry(Guid id, bool track = false);

        Country GetCountry(string name, bool track = false);

        IQueryable<Country> GetCountries();

        void DeleteCountry(Guid id);
    }
}
