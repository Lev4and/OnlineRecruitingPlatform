using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacancyDriverLicenseTypesRepository : IVacancyDriverLicenseTypesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFVacancyDriverLicenseTypesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancyDriverLicenseType(Guid vacancyId, Guid driverLicenseTypeId)
        {
            if (vacancyId == null)
            {
                throw new ArgumentNullException("vacancyId", "Параметр не может быть пустым.");
            }
            
            if (driverLicenseTypeId == null)
            {
                throw new ArgumentNullException("driverLicenseTypeId", "Параметр не может быть пустым.");
            }

            return _context.VacancyDriverLicenseTypes.SingleOrDefault(v =>
                v.VacancyId == vacancyId && v.DriverLicenseTypeId == driverLicenseTypeId) != null;
        }

        public bool SaveVacancyDriverLicenseType(VacancyDriverLicenseType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsVacancyDriverLicenseType(entity.VacancyId, entity.DriverLicenseTypeId))
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

        public VacancyDriverLicenseType GetVacancyDriverLicenseType(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.VacancyDriverLicenseTypes.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.VacancyDriverLicenseTypes.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public VacancyDriverLicenseType GetVacancyDriverLicenseType(Guid vacancyId, Guid driverLicenseTypeId, bool track = false)
        {
            if (vacancyId == null)
            {
                throw new ArgumentNullException("vacancyId", "Параметр не может быть пустым.");
            }
            
            if (driverLicenseTypeId == null)
            {
                throw new ArgumentNullException("driverLicenseTypeId", "Параметр не может быть пустым.");
            }
            
            if (track)
            {
                return _context.VacancyDriverLicenseTypes.SingleOrDefault(v => v.VacancyId == vacancyId && v.DriverLicenseTypeId == driverLicenseTypeId);
            }
            else
            {
                return _context.VacancyDriverLicenseTypes.AsNoTracking().SingleOrDefault(v => v.VacancyId == vacancyId && v.DriverLicenseTypeId == driverLicenseTypeId);
            }
        }

        public IQueryable<VacancyDriverLicenseType> GetVacancyDriverLicenseTypes(bool track = false)
        {
            if (track)
            {
                return _context.VacancyDriverLicenseTypes;
            }
            else
            {
                return _context.VacancyDriverLicenseTypes.AsNoTracking();
            }
        }

        public void DeleteVacancyDriverLicenseType(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancyDriverLicenseType(id);

            _context.VacancyDriverLicenseTypes.Remove(entity);
            _context.SaveChanges();
        }
    }
}