using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacancyBillingTypesRepository : IVacancyBillingTypesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFVacancyBillingTypesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancyBillingType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.VacancyBillingTypes.SingleOrDefault(v => v.Name == name) != null;
        }

        public bool SaveVacancyBillingType(VacancyBillingType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsVacancyBillingType(entity.Name))
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

        public VacancyBillingType GetVacancyBillingType(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.VacancyBillingTypes.SingleOrDefault(v => v.Id == id); 
            }
            else
            {
                return _context.VacancyBillingTypes.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public VacancyBillingType GetVacancyBillingType(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (track)
            {
                return _context.VacancyBillingTypes.SingleOrDefault(v => v.Name == name); 
            }
            else
            {
                return _context.VacancyBillingTypes.AsNoTracking().SingleOrDefault(v => v.Name == name);
            }
        }

        public VacancyBillingType GetVacancyBillingTypeByIdentifierFromHeadHunter(string id, bool track = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.VacancyBillingTypes.SingleOrDefault(v => v.IdentifierFromHeadHunter == id);
            }
            else
            {
                return _context.VacancyBillingTypes.AsNoTracking().SingleOrDefault(v => v.IdentifierFromHeadHunter == id);
            }
        }

        public IQueryable<VacancyBillingType> GetVacancyBillingTypes(bool track = false)
        {
            if (track)
            {
                return _context.VacancyBillingTypes; 
            }
            else
            {
                return _context.VacancyBillingTypes.AsNoTracking();
            }
        }

        public void DeleteVacancyBillingType(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancyBillingType(id);

            _context.VacancyBillingTypes.Remove(entity);
            _context.SaveChanges();
        }
    }
}