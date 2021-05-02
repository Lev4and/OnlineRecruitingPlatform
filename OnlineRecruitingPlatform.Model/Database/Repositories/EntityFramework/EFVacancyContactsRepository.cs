using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacancyContactsRepository : IVacancyContactsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFVacancyContactsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancyContact(Guid vacancyId)
        {
            if (vacancyId == null)
            {
                throw new ArgumentNullException("vacancyId", "Параметр не может быть пустым.");
            }

            return _context.VacancyContacts.SingleOrDefault(v => v.VacancyId == vacancyId) != null;
        }

        public bool SaveVacancyContact(VacancyContact entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsVacancyContact(entity.VacancyId))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetVacancyContact(entity.Id);

                if (oldVersionEntity.VacancyId != entity.VacancyId)
                {
                    if (!ContainsVacancyContact(entity.VacancyId))
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

        public VacancyContact GetVacancyContact(Guid vacancyId, bool track = false)
        {
            if (vacancyId == null)
            {
                throw new ArgumentNullException("vacancyId", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.VacancyContacts.SingleOrDefault(v => v.VacancyId == vacancyId);
            }
            else
            {
                return _context.VacancyContacts.AsNoTracking().SingleOrDefault(v => v.VacancyId == vacancyId);
            }
        }

        public IQueryable<VacancyContact> GetVacancyContacts(bool track = false)
        {
            if (track)
            {
                return _context.VacancyContacts;
            }
            else
            {
                return _context.VacancyContacts.AsNoTracking();
            }
        }

        public void DeleteVacancyContact(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancyContact(id);

            _context.VacancyContacts.Remove(entity);
            _context.SaveChanges();
        }
    }
}