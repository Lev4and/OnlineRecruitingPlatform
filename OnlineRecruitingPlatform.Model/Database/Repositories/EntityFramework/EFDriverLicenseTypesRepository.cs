using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFDriverLicenseTypesRepository : IDriverLicenseTypesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFDriverLicenseTypesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsDriverLicenseType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.DriverLicenseTypes.SingleOrDefault(d => d.Name == name) != null;
        }

        public bool SaveDriverLicenseType(DriverLicenseType entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsDriverLicenseType(entity.Name))
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

        public DriverLicenseType GetDriverLicenseType(Guid id, bool track = false)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.DriverLicenseTypes.SingleOrDefault(d => d.Id == id);
            }
            else
            {
                return _context.DriverLicenseTypes.AsNoTracking().SingleOrDefault(d => d.Id == id);
            }
        }

        public DriverLicenseType GetDriverLicenseType(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.DriverLicenseTypes.SingleOrDefault(d => d.Name == name);
            }
            else
            {
                return _context.DriverLicenseTypes.AsNoTracking().SingleOrDefault(d => d.Name == name);
            }
        }

        public IQueryable<DriverLicenseType> GetDriverLicenseTypes()
        {
            return _context.DriverLicenseTypes;
        }

        public void DeleteDriverLicenseType(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetDriverLicenseType(id);

            _context.DriverLicenseTypes.Remove(entity);
            _context.SaveChanges();
        }
    }
}
