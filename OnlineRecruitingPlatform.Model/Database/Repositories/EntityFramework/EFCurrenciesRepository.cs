using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCurrenciesRepository : ICurrenciesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCurrenciesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCurrency(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Currencies.SingleOrDefault(c => c.Name == name) != null;
        }

        public bool SaveCurrency(Currency entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsCurrency(entity.Name))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetCurrency(entity.Id);

                if (oldVersionEntity.Name != entity.Name)
                {
                    if (!ContainsCurrency(entity.Name))
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

        public Currency GetCurrency(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Currencies.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.Currencies.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public Currency GetCurrency(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Currencies.SingleOrDefault(c => c.Name == name);
            }
            else
            {
                return _context.Currencies.AsNoTracking().SingleOrDefault(c => c.Name == name);
            }
        }

        public IQueryable<Currency> GetCurrencies()
        {
            return _context.Currencies;
        }

        public void DeleteCurrency(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetCurrency(id);

            _context.Currencies.Remove(entity);
            _context.SaveChanges();
        }
    }
}
