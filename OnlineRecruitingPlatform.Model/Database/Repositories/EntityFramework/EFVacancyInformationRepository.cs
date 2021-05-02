using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacancyInformationRepository : IVacancyInformationRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFVacancyInformationRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancyInformation(Guid vacancyId)
        {
            if (vacancyId == null)
            {
                throw new ArgumentNullException("vacancyId", "Параметр не может быть пустым.");
            }

            return _context.VacancyInformation.SingleOrDefault(v => v.VacancyId == vacancyId) != null;
        }

        public bool SaveVacancyInformation(VacancyInformation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsVacancyInformation(entity.VacancyId))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetVacancyInformation(entity.Id);

                if (oldVersionEntity.VacancyId != entity.VacancyId)
                {
                    if (!ContainsVacancyInformation(entity.VacancyId))
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

        public VacancyInformation GetVacancyInformation(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.VacancyInformation.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.VacancyInformation.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public IQueryable<VacancyInformation> GetVacancyInformation(bool track = false)
        {
            if (track)
            {
                return _context.VacancyInformation;
            }
            else
            {
                return _context.VacancyInformation.AsNoTracking();
            }
        }

        public void DeleteVacancyInformation(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancyInformation(id);

            _context.VacancyInformation.Remove(entity);
            _context.SaveChanges();
        }
    }
}