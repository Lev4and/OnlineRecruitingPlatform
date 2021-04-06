using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFEducationLevelsRepository : IEducationLevelsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFEducationLevelsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsEducationLevel(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.EducationLevels.SingleOrDefault(e => e.Name == name) != null;
        }

        public bool SaveEducationLevel(EducationLevel entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsEducationLevel(entity.Name))
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

        public EducationLevel GetEducationLevel(Guid id, bool track = false)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.EducationLevels.SingleOrDefault(e => e.Id == id);
            }
            else
            {
                return _context.EducationLevels.AsNoTracking().SingleOrDefault(e => e.Id == id);
            }
        }

        public EducationLevel GetEducationLevel(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.EducationLevels.SingleOrDefault(e => e.Name == name);
            }
            else
            {
                return _context.EducationLevels.AsNoTracking().SingleOrDefault(e => e.Name == name);
            }
        }

        public IQueryable<EducationLevel> GetEducationLevels()
        {
            return _context.EducationLevels;
        }

        public void DeleteEducationLevel(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetEducationLevel(id);

            _context.EducationLevels.Remove(entity);
            _context.SaveChanges();
        }
    }
}
