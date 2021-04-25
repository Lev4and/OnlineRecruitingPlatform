using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCompanyLocationsRepository : ICompanyLocationsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCompanyLocationsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCompanyLocation(Guid companyId, Guid areaId)
        {
            if (companyId == null)
            {
                throw new ArgumentNullException("companyId", "Параметр не может быть пустым.");
            }

            if (areaId == null)
            {
                throw new ArgumentNullException("areaId", "Параметр не может быть пустым.");
            }

            return _context.CompanyLocations.SingleOrDefault(c => c.CompanyId == companyId && c.AreaId == areaId) != null;
        }

        public bool SaveCompanyLocation(CompanyLocation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsCompanyLocation(entity.CompanyId, entity.AreaId))
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

        public CompanyLocation GetCompanyLocation(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.CompanyLocations.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.CompanyLocations.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public IQueryable<CompanyLocation> GetCompanyLocations(bool track = false)
        {
            if (track)
            {
                return _context.CompanyLocations;
            }
            else
            {
                return _context.CompanyLocations.AsNoTracking();
            }
        }

        public void DeleteCompanyLocation(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetCompanyLocation(id);

            _context.CompanyLocations.Remove(entity);
            _context.SaveChanges();
        }
    }
}
