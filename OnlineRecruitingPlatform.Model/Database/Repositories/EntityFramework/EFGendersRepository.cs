using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFGendersRepository : IGendersRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFGendersRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsGender(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Genders.SingleOrDefault(g => g.Name == name) != null;
        }

        public bool SaveGender(Gender entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsGender(entity.Name))
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

        public Gender GetGender(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Genders.SingleOrDefault(g => g.Id == id);
            }
            else
            {
                return _context.Genders.AsNoTracking().SingleOrDefault(g => g.Id == id);
            }
        }

        public Gender GetGender(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Genders.SingleOrDefault(g => g.Name == name);
            }
            else
            {
                return _context.Genders.AsNoTracking().SingleOrDefault(g => g.Name == name);
            }
        }

        public IQueryable<Gender> GetGenders()
        {
            return _context.Genders;
        }

        public void DeleteGender(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetGender(id);

            _context.Genders.Remove(entity);
            _context.SaveChanges();
        }
    }
}
