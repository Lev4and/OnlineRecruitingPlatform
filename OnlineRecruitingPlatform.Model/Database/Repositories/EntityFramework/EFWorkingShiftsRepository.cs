using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFWorkingShiftsRepository : IWorkingShiftsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFWorkingShiftsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsWorkingShift(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.WorkingShifts.SingleOrDefault(p => p.Name == name) != null;
        }

        public bool SaveWorkingShift(WorkingShift entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsWorkingShift(entity.Name))
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

        public WorkingShift GetWorkingShift(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.WorkingShifts.SingleOrDefault(p => p.Id == id);
            }
            else
            {
                return _context.WorkingShifts.AsNoTracking().SingleOrDefault(p => p.Id == id);
            }
        }

        public WorkingShift GetWorkingShift(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.WorkingShifts.SingleOrDefault(p => p.Name == name);
            }
            else
            {
                return _context.WorkingShifts.AsNoTracking().SingleOrDefault(p => p.Name == name);
            }
        }

        public IQueryable<WorkingShift> GetWorkingShifts(bool track = false)
        {
            if (track)
            {
                return _context.WorkingShifts;
            }
            else
            {
                return _context.WorkingShifts.AsNoTracking();
            }
        }

        public void DeleteWorkingShift(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetWorkingShift(id);

            _context.WorkingShifts.Remove(entity);
            _context.SaveChanges();
        }
    }
}
