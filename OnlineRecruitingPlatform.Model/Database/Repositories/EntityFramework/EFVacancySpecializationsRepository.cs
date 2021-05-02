using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacancySpecializationsRepository : IVacancySpecializationsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFVacancySpecializationsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancySpecialization(Guid vacancyId, Guid specializationId)
        {
            if (vacancyId == null)
            {
                throw new ArgumentNullException("vacancyId", "Параметр не может быть пустым.");
            }
            
            if (specializationId == null)
            {
                throw new ArgumentNullException("specializationId", "Параметр не может быть пустым.");
            }

            return _context.VacancySpecializations.SingleOrDefault(v => 
                v.VacancyId == vacancyId && v.SpecializationId == specializationId) != null;
        }

        public bool SaveVacancySpecialization(VacancySpecialization entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsVacancySpecialization(entity.VacancyId, entity.SpecializationId))
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

        public VacancySpecialization GetVacancySpecialization(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.VacancySpecializations.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.VacancySpecializations.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public VacancySpecialization GetVacancySpecialization(Guid vacancyId, Guid specializationId, bool track = false)
        {
            if (vacancyId == null)
            {
                throw new ArgumentNullException("vacancyId", "Параметр не может быть пустым.");
            }
            
            if (specializationId == null)
            {
                throw new ArgumentNullException("specializationId", "Параметр не может быть пустым.");
            }
            
            if (track)
            {
                return _context.VacancySpecializations.SingleOrDefault(v => v.VacancyId == vacancyId && v.SpecializationId == specializationId);
            }
            else
            {
                return _context.VacancySpecializations.AsNoTracking().SingleOrDefault(v => v.VacancyId == vacancyId && v.SpecializationId == specializationId);
            }
        }

        public IQueryable<VacancySpecialization> GetVacancySpecializations(bool track = false)
        {
            if (track)
            {
                return _context.VacancySpecializations;
            }
            else
            {
                return _context.VacancySpecializations.AsNoTracking();
            }
        }

        public void DeleteVacancySpecialization(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancySpecialization(id);

            _context.VacancySpecializations.Remove(entity);
            _context.SaveChanges();
        }
    }
}