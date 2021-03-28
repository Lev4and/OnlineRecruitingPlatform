using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICurrenciesRepository
    {
        bool ContainsCurrency(string name);

        bool SaveCurrency(Currency entity);

        Currency GetCurrency(Guid id, bool track = false);

        Currency GetCurrency(string name, bool track = false);

        IQueryable<Currency> GetCurrencies();

        void DeleteCurrency(Guid id);
    }
}
