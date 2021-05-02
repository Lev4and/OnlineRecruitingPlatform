using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICurrencyQuotesRepository
    {
        bool ContainsCurrencyQuote(Guid currencyId, DateTime timestamp);

        bool SaveCurrencyQuote(CurrencyQuote entity);

        CurrencyQuote GetCurrencyQuote(Guid id, bool track = false);

        CurrencyQuote GetCurrencyQuote(Guid currencyId, DateTime timestamp, bool track = false);

        IQueryable<CurrencyQuote> GetCurrencyQuotes(bool track = false);

        void DeleteCurrencyQuote(Guid id);
    }
}