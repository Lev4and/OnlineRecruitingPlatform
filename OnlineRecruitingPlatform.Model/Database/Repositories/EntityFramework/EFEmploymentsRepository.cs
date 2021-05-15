using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFEmploymentsRepository : IEmploymentsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFEmploymentsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsEmployment(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Employments.SingleOrDefault(e => e.Name == name) != null;
        }

        public bool SaveEmployment(Employment entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsEmployment(entity.Name))
            {
                if(entity.Id == default)
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

        public Employment GetEmployment(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Employments.SingleOrDefault(e => e.Id == id);
            }
            else
            {
                return _context.Employments.AsNoTracking().SingleOrDefault(e => e.Id == id);
            }
        }

        public Employment GetEmployment(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Employments.SingleOrDefault(e => e.Name == name);
            }
            else
            {
                return _context.Employments.AsNoTracking().SingleOrDefault(e => e.Name == name);
            }
        }

        public Employment GetEmploymentByIdentifierFromHeadHunter(string id, bool track = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Employments.SingleOrDefault(s => s.IdentifierFromHeadHunter == id);
            }
            else
            {
                return _context.Employments.AsNoTracking().SingleOrDefault(s => s.IdentifierFromHeadHunter == id);
            }
        }

        public Employment GetEmploymentByIdentifierFromZarplataRu(int id, bool track = false)
        {
            if (track)
            {
                return _context.Employments.SingleOrDefault(s => s.IdentifierFromZarplataRu == id);
            }
            else
            {
                return _context.Employments.AsNoTracking().SingleOrDefault(s => s.IdentifierFromZarplataRu == id);
            }
        }

        public IQueryable<Employment> GetEmployments()
        {
            return _context.Employments;
        }

        public void DeleteEmployment(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetEmployment(id);

            _context.Employments.Remove(entity);
            _context.SaveChanges();
        }
    }
}
