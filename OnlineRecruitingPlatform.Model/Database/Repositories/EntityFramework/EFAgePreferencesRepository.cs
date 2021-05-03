using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFAgePreferencesRepository : IAgePreferencesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFAgePreferencesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsAgePreference(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.AgePreferences.SingleOrDefault(p => p.Name == name) != null;
        }

        public bool SaveAgePreference(AgePreference entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsAgePreference(entity.Name))
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

        public AgePreference GetAgePreference(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.AgePreferences.SingleOrDefault(p => p.Id == id);
            }
            else
            {
                return _context.AgePreferences.AsNoTracking().SingleOrDefault(p => p.Id == id);
            }
        }

        public AgePreference GetAgePreference(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.AgePreferences.SingleOrDefault(p => p.Name == name);
            }
            else
            {
                return _context.AgePreferences.AsNoTracking().SingleOrDefault(p => p.Name == name);
            }
        }

        public IQueryable<AgePreference> GetAgePreferences(bool track = false)
        {
            if (track)
            {
                return _context.AgePreferences;
            }
            else
            {
                return _context.AgePreferences.AsNoTracking();
            }
        }

        public void DeleteAgePreference(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetAgePreference(id);

            _context.AgePreferences.Remove(entity);
            _context.SaveChanges();
        }
    }
}
