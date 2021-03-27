using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFApplicantCommentsOrdersRepository : IApplicantCommentsOrdersRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFApplicantCommentsOrdersRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsApplicantCommentsOrder(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.ApplicantCommentsOrders.SingleOrDefault(a => a.Name == name) != null;
        }

        public bool SaveApplicantCommentsOrder(ApplicantCommentsOrder entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsApplicantCommentsOrder(entity.Name))
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

        public ApplicantCommentsOrder GetApplicantCommentsOrder(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.ApplicantCommentsOrders.SingleOrDefault(a => a.Id == id);
            }
            else
            {
                return _context.ApplicantCommentsOrders.AsNoTracking().SingleOrDefault(a => a.Id == id);
            }
        }

        public ApplicantCommentsOrder GetApplicantCommentsOrder(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.ApplicantCommentsOrders.SingleOrDefault(a => a.Name == name);
            }
            else
            {
                return _context.ApplicantCommentsOrders.AsNoTracking().SingleOrDefault(a => a.Name == name);
            }
        }

        public IQueryable<ApplicantCommentsOrder> GetApplicantCommentsOrders()
        {
            return _context.ApplicantCommentsOrders;
        }

        public void DeleteApplicantCommentsOrder(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetApplicantCommentsOrder(id);

            _context.ApplicantCommentsOrders.Remove(entity);
            _context.SaveChanges();
        }
    }
}
