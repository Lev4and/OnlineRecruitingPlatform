using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFBusinessTripReadinessTypesRepository : IBusinessTripReadinessTypesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFBusinessTripReadinessTypesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsBusinessTripReadiness(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.BusinessTripReadinessTypes.SingleOrDefault(b => b.Name == name) != null;
        }

        public bool SaveBusinessTripReadiness(BusinessTripReadiness entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsBusinessTripReadiness(entity.Name))
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

        public BusinessTripReadiness GetBusinessTripReadiness(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.BusinessTripReadinessTypes.SingleOrDefault(b => b.Id == id);
            }
            else
            {
                return _context.BusinessTripReadinessTypes.AsNoTracking().SingleOrDefault(b => b.Id == id);
            }
        }

        public BusinessTripReadiness GetBusinessTripReadiness(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.BusinessTripReadinessTypes.SingleOrDefault(b => b.Name == name);
            }
            else
            {
                return _context.BusinessTripReadinessTypes.AsNoTracking().SingleOrDefault(b => b.Name == name);
            }
        }

        public IQueryable<BusinessTripReadiness> GetBusinessTripReadinessTypes()
        {
            return _context.BusinessTripReadinessTypes;
        }

        public void DeleteBusinessTripReadiness(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetBusinessTripReadiness(id);

            _context.BusinessTripReadinessTypes.Remove(entity);
            _context.SaveChanges();
        }
    }
}
