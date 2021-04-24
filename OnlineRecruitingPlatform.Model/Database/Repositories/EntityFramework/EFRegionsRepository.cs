using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFRegionsRepository : IRegionsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFRegionsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsRegion(Guid countryId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Regions.SingleOrDefault(r => r.CountryId == countryId && r.Name == name) != null;
        }

        public bool SaveRegion(Region entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if(entity.Id == default)
            {
                if (!ContainsRegion(entity.CountryId, entity.Name))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetRegion(entity.Id);

                if (oldVersionEntity.CountryId != entity.CountryId || oldVersionEntity.Name != entity.Name)
                {
                    if (!ContainsRegion(entity.CountryId, entity.Name))
                    {
                        _context.Entry(entity).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public Region GetRegion(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Regions.SingleOrDefault(r => r.Id == id);
            }
            else
            {
                return _context.Regions.AsNoTracking().SingleOrDefault(r => r.Id == id);
            }
        }

        public Region GetRegion(Guid countryId, string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Regions.SingleOrDefault(r => r.CountryId == countryId && r.Name == name);
            }
            else
            {
                return _context.Regions.AsNoTracking().SingleOrDefault(r => r.CountryId == countryId && r.Name == name);
            }
        }

        public IQueryable<Region> GetRegions(bool track = false)
        {
            if (track)
            {
                return _context.Regions;
            }
            else
            {
                return _context.Regions.AsNoTracking();
            }
        }

        public void DeleteRegion(Guid id)
        {
            var entity = GetRegion(id);

            _context.Regions.Remove(entity);
            _context.SaveChanges();
        }
    }
}
