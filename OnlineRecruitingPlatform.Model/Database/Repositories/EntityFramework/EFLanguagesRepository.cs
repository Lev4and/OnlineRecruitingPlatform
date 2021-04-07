using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFLanguagesRepository : ILanguagesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFLanguagesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsLanguage(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Languages.SingleOrDefault(l => l.Name == name) != null;
        }

        public bool SaveLanguage(Language entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsLanguage(entity.Name))
            {
                if(entity.Id == default)
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

        public Language GetLanguage(Guid id, bool track = false)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Languages.SingleOrDefault(l => l.Id == id);
            }
            else
            {
                return _context.Languages.AsNoTracking().SingleOrDefault(l => l.Id == id);
            }
        }

        public Language GetLanguage(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Languages.SingleOrDefault(l => l.Name == name);
            }
            else
            {
                return _context.Languages.AsNoTracking().SingleOrDefault(l => l.Name == name);
            }
        }

        public IQueryable<Language> GetLanguages()
        {
            return _context.Languages;
        }

        public void DeleteLanguage(Guid id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetLanguage(id);

            _context.Languages.Remove(entity);
            _context.SaveChanges();
        }
    }
}
