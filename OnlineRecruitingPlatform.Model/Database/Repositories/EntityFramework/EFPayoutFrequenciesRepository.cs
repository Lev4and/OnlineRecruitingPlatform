using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFPayoutFrequenciesRepository : IPayoutFrequenciesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFPayoutFrequenciesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsPayoutFrequency(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.PayoutFrequencies.SingleOrDefault(p => p.Name == name) != null;
        }

        public bool SavePayoutFrequency(PayoutFrequency entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsPayoutFrequency(entity.Name))
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

        public PayoutFrequency GetPayoutFrequency(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.PayoutFrequencies.SingleOrDefault(p => p.Id == id);
            }
            else
            {
                return _context.PayoutFrequencies.AsNoTracking().SingleOrDefault(p => p.Id == id);
            }
        }

        public PayoutFrequency GetPayoutFrequency(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.PayoutFrequencies.SingleOrDefault(p => p.Name == name);
            }
            else
            {
                return _context.PayoutFrequencies.AsNoTracking().SingleOrDefault(p => p.Name == name);
            }
        }

        public IQueryable<PayoutFrequency> GetPayoutFrequencies(bool track = false)
        {
            if (track)
            {
                return _context.PayoutFrequencies;
            }
            else
            {
                return _context.PayoutFrequencies.AsNoTracking();
            }
        }

        public void DeletePayoutFrequency(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetPayoutFrequency(id);

            _context.PayoutFrequencies.Remove(entity);
            _context.SaveChanges();
        }
    }
}
