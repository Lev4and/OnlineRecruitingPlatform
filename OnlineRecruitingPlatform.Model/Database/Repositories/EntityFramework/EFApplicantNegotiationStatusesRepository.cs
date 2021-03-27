using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFApplicantNegotiationStatusesRepository : IApplicantNegotiationStatusesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFApplicantNegotiationStatusesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsApplicantNegotiationStatus(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.ApplicantNegotiationStatuses.SingleOrDefault(a => a.Name == name) != null;
        }

        public bool SaveApplicantNegotiationStatus(ApplicantNegotiationStatus entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsApplicantNegotiationStatus(entity.Name))
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

        public ApplicantNegotiationStatus GetApplicantNegotiationStatus(Guid id, bool track = false)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.ApplicantNegotiationStatuses.SingleOrDefault(a => a.Id == id);
            }
            else
            {
                return _context.ApplicantNegotiationStatuses.AsNoTracking().SingleOrDefault(a => a.Id == id);
            }
        }

        public ApplicantNegotiationStatus GetApplicantNegotiationStatus(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.ApplicantNegotiationStatuses.SingleOrDefault(a => a.Name == name);
            }
            else
            {
                return _context.ApplicantNegotiationStatuses.AsNoTracking().SingleOrDefault(a => a.Name == name);
            }
        }

        public IQueryable<ApplicantNegotiationStatus> GetApplicantNegotiationStatuses()
        {
            return _context.ApplicantNegotiationStatuses;
        }

        public void DeleteApplicantNegotiationStatus(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetApplicantNegotiationStatus(id);

            _context.ApplicantNegotiationStatuses.Remove(entity);
            _context.SaveChanges();
        }
    }
}
