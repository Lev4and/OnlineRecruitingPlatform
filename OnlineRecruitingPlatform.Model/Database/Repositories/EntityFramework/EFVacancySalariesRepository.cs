using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacancySalariesRepository : IVacancySalariesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFVacancySalariesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancySalary(Guid vacancyId)
        {
            if (vacancyId == null)
            {
                throw new ArgumentNullException("vacancyId", "Параметр не может быть пустым.");
            }

            return _context.VacancySalaries.SingleOrDefault(v => v.VacancyId == vacancyId) != null;
        }

        public bool SaveVacancySalary(VacancySalary entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsVacancySalary(entity.VacancyId))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetVacancySalary(entity.Id);

                if (oldVersionEntity.VacancyId != entity.VacancyId)
                {
                    if (!ContainsVacancySalary(entity.VacancyId))
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

        public VacancySalary GetVacancySalary(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.VacancySalaries.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.VacancySalaries.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public IQueryable<VacancySalary> GetVacancySalaries(bool track = false)
        {
            if (track)
            {
                return _context.VacancySalaries;
            }
            else
            {
                return _context.VacancySalaries.AsNoTracking();
            }
        }

        public void DeleteVacancySalary(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancySalary(id);

            _context.VacancySalaries.Remove(entity);
            _context.SaveChanges();
        }
    }
}