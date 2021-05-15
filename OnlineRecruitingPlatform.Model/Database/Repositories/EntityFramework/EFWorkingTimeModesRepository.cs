using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFWorkingTimeModesRepository : IWorkingTimeModesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFWorkingTimeModesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsWorkingTimeModes(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.WorkingTimeModes.SingleOrDefault(v => v.Name == name) != null;
        }

        public bool SaveWorkingTimeModes(WorkingTimeModes entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsWorkingTimeModes(entity.Name))
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

        public WorkingTimeModes GetWorkingTimeModes(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.WorkingTimeModes.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.WorkingTimeModes.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public WorkingTimeModes GetWorkingTimeModes(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (track)
            {
                return _context.WorkingTimeModes.SingleOrDefault(v => v.Name == name);
            }
            else
            {
                return _context.WorkingTimeModes.AsNoTracking().SingleOrDefault(v => v.Name == name);
            }
        }

        public WorkingTimeModes GetWorkingTimeModesByIdentifierFromHeadHunter(string id, bool track = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.WorkingTimeModes.SingleOrDefault(v => v.IdentifierFromHeadHunter == id);
            }
            else
            {
                return _context.WorkingTimeModes.AsNoTracking().SingleOrDefault(v => v.IdentifierFromHeadHunter == id);
            }
        }

        public IQueryable<WorkingTimeModes> GetWorkingTimeModes(bool track = false)
        {
            if (track)
            {
                return _context.WorkingTimeModes;
            }
            else
            {
                return _context.WorkingTimeModes.AsNoTracking();
            }
        }

        public void DeleteWorkingTimeModes(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetWorkingTimeModes(id);

            _context.WorkingTimeModes.Remove(entity);
            _context.SaveChanges();
        }
    }
}