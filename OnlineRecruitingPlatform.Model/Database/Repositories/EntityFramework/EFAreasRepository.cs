using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using ArgumentNullException = System.ArgumentNullException;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFAreasRepository : IAreasRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFAreasRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsArea(Guid regionId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Areas.SingleOrDefault(a => a.RegionId == regionId && a.Name == name) != null;
        }

        public bool SaveArea(Area entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsArea(entity.RegionId, entity.Name))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetArea(entity.Id);

                if (oldVersionEntity.RegionId != entity.RegionId || oldVersionEntity.Name != entity.Name)
                {
                    if (!ContainsArea(entity.RegionId, entity.Name))
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

        public Area GetArea(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Areas.SingleOrDefault(a => a.Id == id);
            }
            else
            {
                return _context.Areas.AsNoTracking().SingleOrDefault(a => a.Id == id);
            }
        }

        public Area GetArea(Guid regionId, string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Areas.SingleOrDefault(a => a.RegionId == regionId && a.Name == name);
            }
            else
            {
                return _context.Areas.AsNoTracking().SingleOrDefault(a => a.RegionId == regionId && a.Name == name);
            }
        }

        public IQueryable<Area> GetAreas()
        {
            return _context.Areas;
        }

        public void DeleteArea(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetArea(id);

            _context.Areas.Remove(entity);
            _context.SaveChanges();
        }
    }
}
