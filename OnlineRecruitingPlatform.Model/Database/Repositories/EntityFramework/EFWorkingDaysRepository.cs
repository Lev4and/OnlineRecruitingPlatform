using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFWorkingDaysRepository : IWorkingDaysRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFWorkingDaysRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsWorkingDays(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.WorkingDays.SingleOrDefault(v => v.Name == name) != null;
        }

        public bool SaveWorkingDays(WorkingDays entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsWorkingDays(entity.Name))
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

        public WorkingDays GetWorkingDays(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.WorkingDays.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.WorkingDays.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public WorkingDays GetWorkingDays(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (track)
            {
                return _context.WorkingDays.SingleOrDefault(v => v.Name == name);
            }
            else
            {
                return _context.WorkingDays.AsNoTracking().SingleOrDefault(v => v.Name == name);
            }
        }

        public WorkingDays GetWorkingDaysByIdentifierFromHeadHunter(string id, bool track = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.WorkingDays.SingleOrDefault(v => v.IdentifierFromHeadHunter == id);
            }
            else
            {
                return _context.WorkingDays.AsNoTracking().SingleOrDefault(v => v.IdentifierFromHeadHunter == id);
            }
        }

        public IQueryable<WorkingDays> GetWorkingDays(bool track = false)
        {
            if (track)
            {
                return _context.WorkingDays;
            }
            else
            {
                return _context.WorkingDays.AsNoTracking();
            }
        }

        public void DeleteWorkingDays(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetWorkingDays(id);

            _context.WorkingDays.Remove(entity);
            _context.SaveChanges();
        }
    }
}