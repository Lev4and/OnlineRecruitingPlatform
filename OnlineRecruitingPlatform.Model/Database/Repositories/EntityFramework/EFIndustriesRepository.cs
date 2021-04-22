using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFIndustriesRepository : IIndustriesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFIndustriesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsIndustry(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Industries.SingleOrDefault(i => i.Name == name) != null;
        }

        public bool SaveIndustry(Industry entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsIndustry(entity.Name))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetIndustry(entity.Id);

                if (oldVersionEntity.Name != entity.Name)
                {
                    if (!ContainsIndustry(entity.Name))
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

        public Industry GetIndustry(Guid id, bool track = false)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Industries.SingleOrDefault(i => i.Id == id);
            }
            else
            {
                return _context.Industries.AsNoTracking().SingleOrDefault(i => i.Id == id);
            }
        }

        public Industry GetIndustry(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Industries.SingleOrDefault(i => i.Name == name);
            }
            else
            {
                return _context.Industries.AsNoTracking().SingleOrDefault(i => i.Name == name);
            }
        }

        public Industry GetIndustryByCode(string code, bool track = false)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("code", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Industries.SingleOrDefault(i => i.Code == code);
            }
            else
            {
                return _context.Industries.AsNoTracking().SingleOrDefault(i => i.Code == code);
            }
        }

        public IQueryable<Industry> GetIndustries()
        {
            return _context.Industries;
        }

        public void DeleteIndustry(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetIndustry(id);

            _context.Industries.Remove(entity);
            _context.SaveChanges();
        }
    }
}
