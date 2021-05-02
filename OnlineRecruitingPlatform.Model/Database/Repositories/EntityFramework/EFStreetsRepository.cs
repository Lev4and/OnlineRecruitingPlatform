using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFStreetsRepository : IStreetsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFStreetsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsStreet(Guid areaId, string name)
        {
            if (areaId == null)
            {
                throw new ArgumentNullException("areaId", "Параметр не может быть пустым.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Streets.SingleOrDefault(s => s.AreaId == areaId && s.Name == name) != null;
        }

        public bool SaveStreet(Street entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsStreet(entity.AreaId, entity.Name))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetStreet(entity.Id);

                if (oldVersionEntity.AreaId != entity.AreaId || oldVersionEntity.Name != entity.Name)
                {
                    if (!ContainsStreet(entity.AreaId, entity.Name))
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

        public Street GetStreet(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Streets.SingleOrDefault(s => s.Id == id);
            }
            else
            {
                return _context.Streets.AsNoTracking().SingleOrDefault(s => s.Id == id);
            }
        }

        public Street GetStreet(Guid areaId, string name, bool track = false)
        {
            if (areaId == null)
            {
                throw new ArgumentNullException("areaId", "Параметр не может быть пустым.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (track)
            {
                return _context.Streets.SingleOrDefault(s => s.AreaId == areaId && s.Name == name);
            }
            else
            {
                return _context.Streets.AsNoTracking().SingleOrDefault(s => s.AreaId == areaId && s.Name == name);
            }
        }

        public IQueryable<Street> GetStreets(bool track = false)
        {
            if (track)
            {
                return _context.Streets;
            }
            else
            {
                return _context.Streets.AsNoTracking();
            }
        }

        public void DeleteStreet(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetStreet(id);

            _context.Streets.Remove(entity);
            _context.SaveChanges();
        }
    }
}