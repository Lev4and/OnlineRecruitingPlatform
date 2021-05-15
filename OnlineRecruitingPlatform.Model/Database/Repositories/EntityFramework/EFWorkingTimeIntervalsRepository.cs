using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFWorkingTimeIntervalsRepository : IWorkingTimeIntervalsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFWorkingTimeIntervalsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsWorkingTimeIntervals(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.WorkingTimeIntervals.SingleOrDefault(v => v.Name == name) != null;
        }

        public bool SaveWorkingTimeIntervals(WorkingTimeIntervals entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsWorkingTimeIntervals(entity.Name))
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

        public WorkingTimeIntervals GetWorkingTimeIntervals(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.WorkingTimeIntervals.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.WorkingTimeIntervals.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public WorkingTimeIntervals GetWorkingTimeIntervals(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (track)
            {
                return _context.WorkingTimeIntervals.SingleOrDefault(v => v.Name == name);
            }
            else
            {
                return _context.WorkingTimeIntervals.AsNoTracking().SingleOrDefault(v => v.Name == name);
            }
        }

        public WorkingTimeIntervals GetWorkingTimeIntervalsByIdentifierFromHeadHunter(string id, bool track = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.WorkingTimeIntervals.SingleOrDefault(v => v.IdentifierFromHeadHunter == id);
            }
            else
            {
                return _context.WorkingTimeIntervals.AsNoTracking().SingleOrDefault(v => v.IdentifierFromHeadHunter == id);
            }
        }

        public IQueryable<WorkingTimeIntervals> GetWorkingTimeIntervals(bool track = false)
        {
            if (track)
            {
                return _context.WorkingTimeIntervals;
            }
            else
            {
                return _context.WorkingTimeIntervals.AsNoTracking();
            }
        }

        public void DeleteWorkingTimeIntervals(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetWorkingTimeIntervals(id);

            _context.WorkingTimeIntervals.Remove(entity);
            _context.SaveChanges();
        }
    }
}