using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacancyTypesRepository : IVacancyTypesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;
        
        public EFVacancyTypesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancyType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.VacancyTypes.SingleOrDefault(v => v.Name == name) != null;
        }

        public bool SaveVacancyType(VacancyType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsVacancyType(entity.Name))
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

        public VacancyType GetVacancyType(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.VacancyTypes.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.VacancyTypes.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public VacancyType GetVacancyType(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (track)
            {
                return _context.VacancyTypes.SingleOrDefault(v => v.Name == name);
            }
            else
            {
                return _context.VacancyTypes.AsNoTracking().SingleOrDefault(v => v.Name == name);
            }
        }

        public VacancyType GetVacancyTypeByIdentifierFromHeadHunter(string id, bool track = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.VacancyTypes.SingleOrDefault(v => v.IdentifierFromHeadHunter == id);
            }
            else
            {
                return _context.VacancyTypes.AsNoTracking().SingleOrDefault(v => v.IdentifierFromHeadHunter == id);
            }
        }

        public IQueryable<VacancyType> GetVacancyTypes(bool track = false)
        {
            if (track)
            {
                return _context.VacancyTypes;
            }
            else
            {
                return _context.VacancyTypes.AsNoTracking();
            }
        }

        public void DeleteVacancyType(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancyType(id);

            _context.VacancyTypes.Remove(entity);
            _context.SaveChanges();
        }
    }
}