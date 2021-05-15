using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacancyVisibilityTypesRepository : IVacancyVisibilityTypesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFVacancyVisibilityTypesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancyVisibilityType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.VacancyVisibilityTypes.SingleOrDefault(p => p.Name == name) != null;
        }

        public bool SaveVacancyVisibilityType(VacancyVisibilityType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsVacancyVisibilityType(entity.Name))
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

        public VacancyVisibilityType GetVacancyVisibilityType(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.VacancyVisibilityTypes.SingleOrDefault(p => p.Id == id);
            }
            else
            {
                return _context.VacancyVisibilityTypes.AsNoTracking().SingleOrDefault(p => p.Id == id);
            }
        }

        public VacancyVisibilityType GetVacancyVisibilityType(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.VacancyVisibilityTypes.SingleOrDefault(p => p.Name == name);
            }
            else
            {
                return _context.VacancyVisibilityTypes.AsNoTracking().SingleOrDefault(p => p.Name == name);
            }
        }

        public IQueryable<VacancyVisibilityType> GetVacancyVisibilityTypes(bool track = false)
        {
            if (track)
            {
                return _context.VacancyVisibilityTypes;
            }
            else
            {
                return _context.VacancyVisibilityTypes.AsNoTracking();
            }
        }

        public void DeleteVacancyVisibilityType(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancyVisibilityType(id);

            _context.VacancyVisibilityTypes.Remove(entity);
            _context.SaveChanges();
        }
    }
}