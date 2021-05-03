using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFPaidPeriodsRepository : IPaidPeriodsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFPaidPeriodsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsPaidPeriod(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.PaidPeriods.SingleOrDefault(p => p.Name == name) != null;
        }

        public bool SavePaidPeriod(PaidPeriod entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsPaidPeriod(entity.Name))
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

        public PaidPeriod GetPaidPeriod(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.PaidPeriods.SingleOrDefault(p => p.Id == id);
            }
            else
            {
                return _context.PaidPeriods.AsNoTracking().SingleOrDefault(p => p.Id == id);
            }
        }

        public PaidPeriod GetPaidPeriod(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.PaidPeriods.SingleOrDefault(p => p.Name == name);
            }
            else
            {
                return _context.PaidPeriods.AsNoTracking().SingleOrDefault(p => p.Name == name);
            }
        }

        public IQueryable<PaidPeriod> GetPaidPeriods(bool track = false)
        {
            if (track)
            {
                return _context.PaidPeriods;
            }
            else
            {
                return _context.PaidPeriods.AsNoTracking();
            }
        }

        public void DeletePaidPeriod(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetPaidPeriod(id);

            _context.PaidPeriods.Remove(entity);
            _context.SaveChanges();
        }
    }
}
