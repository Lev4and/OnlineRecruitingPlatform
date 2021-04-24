using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCountiesRepository : ICountiesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCountiesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCountry(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Countries.SingleOrDefault(c => c.Name == name) != null;
        }

        public bool SaveCountry(Country entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsCountry(entity.Name))
            {
                if (entity.Id == default)
                {
                    _context.Entry(entity).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public Country GetCountry(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Countries.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.Countries.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public Country GetCountry(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Countries.SingleOrDefault(c => c.Name == name);
            }
            else
            {
                return _context.Countries.AsNoTracking().SingleOrDefault(c => c.Name == name);
            }
        }

        public IQueryable<Country> GetCountries()
        {
            return _context.Countries;
        }

        public void DeleteCountry(Guid id)
        {
            var entity = GetCountry(id);

            _context.Countries.Remove(entity);
            _context.SaveChanges();
        }
    }
}
