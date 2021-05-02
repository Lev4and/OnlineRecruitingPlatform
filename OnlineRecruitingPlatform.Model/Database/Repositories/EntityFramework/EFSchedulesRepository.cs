using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFSchedulesRepository : ISchedulesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFSchedulesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsSchedule(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Schedules.SingleOrDefault(s => s.Name == name) != null;
        }

        public bool SaveSchedule(Schedule entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsSchedule(entity.Name))
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

        public Schedule GetSchedule(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Schedules.SingleOrDefault(s => s.Id == id);
            }
            else
            {
                return _context.Schedules.AsNoTracking().SingleOrDefault(s => s.Id == id);
            }
        }

        public Schedule GetSchedule(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (track)
            {
                return _context.Schedules.SingleOrDefault(s => s.Name == name);
            }
            else
            {
                return _context.Schedules.AsNoTracking().SingleOrDefault(s => s.Name == name);
            }
        }

        public IQueryable<Schedule> GetSchedules(bool track = false)
        {
            if (track)
            {
                return _context.Schedules;
            }
            else
            {
                return _context.Schedules.AsNoTracking();
            }
        }

        public void DeleteSchedule(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetSchedule(id);

            _context.Schedules.Remove(entity);
            _context.SaveChanges();
        }
    }
}