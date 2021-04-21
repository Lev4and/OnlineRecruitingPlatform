using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFSubIndustriesRepository : ISubIndustriesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFSubIndustriesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsSubIndustry(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.SubIndustries.SingleOrDefault(s => s.Name == name) != null;
        }

        public bool SaveSubIndustry(SubIndustry entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsSubIndustry(entity.Name))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetSubIndustry(entity.Id);

                if (oldVersionEntity.Name != entity.Name)
                {
                    if (!ContainsSubIndustry(entity.Name))
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

        public SubIndustry GetSubIndustry(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.SubIndustries.SingleOrDefault(i => i.Id == id);
            }
            else
            {
                return _context.SubIndustries.AsNoTracking().SingleOrDefault(i => i.Id == id);
            }
        }

        public SubIndustry GetSubIndustry(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.SubIndustries.SingleOrDefault(i => i.Name == name);
            }
            else
            {
                return _context.SubIndustries.AsNoTracking().SingleOrDefault(i => i.Name == name);
            }
        }

        public IQueryable<SubIndustry> GetSubIndustries()
        {
            return _context.SubIndustries;
        }

        public void DeleteSubIndustry(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetSubIndustry(id);

            _context.SubIndustries.Remove(entity);
            _context.SaveChanges();
        }
    }
}
