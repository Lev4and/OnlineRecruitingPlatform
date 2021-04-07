using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFEmployerTypesRepository : IEmployerTypesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFEmployerTypesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsEmployerType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.EmployerTypes.SingleOrDefault(e => e.Name == name) != null;
        }

        public bool SaveEmployerType(EmployerType entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsEmployerType(entity.Name))
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

        public EmployerType GetEmployerType(Guid id, bool track = false)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.EmployerTypes.SingleOrDefault(e => e.Id == id);
            }
            else
            {
                return _context.EmployerTypes.AsNoTracking().SingleOrDefault(e => e.Id == id);
            }
        }

        public EmployerType GetEmployerType(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.EmployerTypes.SingleOrDefault(e => e.Name == name);
            }
            else
            {
                return _context.EmployerTypes.AsNoTracking().SingleOrDefault(e => e.Name == name);
            }
        }

        public IQueryable<EmployerType> GetEmployerTypes()
        {
            return _context.EmployerTypes;
        }

        public void DeleteEmployerType(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetEmployerType(id);

            _context.EmployerTypes.Remove(entity);
            _context.SaveChanges();
        }
    }
}
