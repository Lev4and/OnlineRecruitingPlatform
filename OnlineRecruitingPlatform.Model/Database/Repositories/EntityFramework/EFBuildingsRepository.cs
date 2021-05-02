using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFBuildingsRepository : IBuildingsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFBuildingsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsBuilding(Guid streetId, string name)
        {
            if (streetId == null)
            {
                throw new ArgumentNullException("streetId", "Параметр не может быть пустым.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Buildings.SingleOrDefault(b => b.StreetId == streetId && b.Name == name) != null;
        }

        public bool SaveBuilding(Building entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsBuilding(entity.StreetId, entity.Name))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetBuilding(entity.Id);

                if (oldVersionEntity.StreetId != entity.StreetId || oldVersionEntity.Name != entity.Name)
                {
                    if (!ContainsBuilding(entity.StreetId, entity.Name))
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

        public Building GetBuilding(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Buildings.SingleOrDefault(b => b.Id == id);
            }
            else
            {
                return _context.Buildings.AsNoTracking().SingleOrDefault(b => b.Id == id);
            }
        }

        public Building GetBuilding(Guid streetId, string name, bool track = false)
        {
            if (streetId == null)
            {
                throw new ArgumentNullException("streetId", "Параметр не может быть пустым.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Buildings.SingleOrDefault(b => b.StreetId == streetId && b.Name == name);
            }
            else
            {
                return _context.Buildings.AsNoTracking().SingleOrDefault(b => b.StreetId == streetId && b.Name == name);
            }
        }

        public IQueryable<Building> GetBuildings(bool track = false)
        {
            if (track)
            {
                return _context.Buildings;
            }
            else
            {
                return _context.Buildings.AsNoTracking();
            }
        }

        public void DeleteBuildings(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetBuilding(id);

            _context.Buildings.Remove(entity);
            _context.SaveChanges();
        }
    }
}