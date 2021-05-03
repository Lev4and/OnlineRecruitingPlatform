using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFPlaceOfWorksRepository : IPlaceOfWorksRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFPlaceOfWorksRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsPlaceOfWork(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.PlaceOfWorks.SingleOrDefault(p => p.Name == name) != null;
        }

        public bool SavePlaceOfWork(PlaceOfWork entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsPlaceOfWork(entity.Name))
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

        public PlaceOfWork GetPlaceOfWork(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.PlaceOfWorks.SingleOrDefault(p => p.Id == id);
            }
            else
            {
                return _context.PlaceOfWorks.AsNoTracking().SingleOrDefault(p => p.Id == id);
            }
        }

        public PlaceOfWork GetPlaceOfWork(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.PlaceOfWorks.SingleOrDefault(p => p.Name == name);
            }
            else
            {
                return _context.PlaceOfWorks.AsNoTracking().SingleOrDefault(p => p.Name == name);
            }
        }

        public IQueryable<PlaceOfWork> GetPlaceOfWorks(bool track = false)
        {
            if (track)
            {
                return _context.PlaceOfWorks;
            }
            else
            {
                return _context.PlaceOfWorks.AsNoTracking();
            }
        }

        public void DeletePlaceOfWork(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetPlaceOfWork(id);

            _context.PlaceOfWorks.Remove(entity);
            _context.SaveChanges();
        }
    }
}
