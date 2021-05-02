using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCurrencyQuotesRepository : ICurrencyQuotesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCurrencyQuotesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCurrencyQuote(Guid currencyId, DateTime timestamp)
        {
            if (currencyId == null)
            {
                throw new ArgumentNullException("currencyId", "Параметр не может быть пустым.");
            }

            if (timestamp == null)
            {
                throw new ArgumentNullException("timestamp", "Параметр не может быть пустым.");
            }

            return _context.CurrencyQuotes.SingleOrDefault(c =>
                c.CurrencyId == currencyId && c.Timestamp == timestamp) != null;
        }

        public bool SaveCurrencyQuote(CurrencyQuote entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsCurrencyQuote(entity.CurrencyId, entity.Timestamp))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetCurrencyQuote(entity.Id);

                if (oldVersionEntity.CurrencyId != entity.CurrencyId || oldVersionEntity.Timestamp != entity.Timestamp)
                {
                    if (!ContainsCurrencyQuote(entity.CurrencyId, entity.Timestamp))
                    {
                        _context.Entry(entity).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public CurrencyQuote GetCurrencyQuote(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.CurrencyQuotes.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.CurrencyQuotes.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public CurrencyQuote GetCurrencyQuote(Guid currencyId, DateTime timestamp, bool track = false)
        {
            if (currencyId == null)
            {
                throw new ArgumentNullException("currencyId", "Параметр не может быть пустым.");
            }

            if (timestamp == null)
            {
                throw new ArgumentNullException("timestamp", "Параметр не может быть пустым.");
            }
            
            if (track)
            {
                return _context.CurrencyQuotes.SingleOrDefault(c => c.CurrencyId == currencyId && c.Timestamp == timestamp);
            }
            else
            {
                return _context.CurrencyQuotes.AsNoTracking().SingleOrDefault(c => c.CurrencyId == currencyId && c.Timestamp == timestamp);
            }
        }

        public IQueryable<CurrencyQuote> GetCurrencyQuotes(bool track = false)
        {
            if (track)
            {
                return _context.CurrencyQuotes;
            }
            else
            {
                return _context.CurrencyQuotes.AsNoTracking();
            }
        }

        public void DeleteCurrencyQuote(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }
            
            var entity = GetCurrencyQuote(id);

            _context.CurrencyQuotes.Remove(entity);
            _context.SaveChanges();
        }
    }
}