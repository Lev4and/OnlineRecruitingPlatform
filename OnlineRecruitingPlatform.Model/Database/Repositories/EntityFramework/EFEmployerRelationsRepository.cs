using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFEmployerRelationsRepository : IEmployerRelationsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFEmployerRelationsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsEmployerRelation(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.EmployerRelations.SingleOrDefault(e => e.Name == name) != null;
        }

        public bool SaveEmployerRelation(EmployerRelation entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsEmployerRelation(entity.Name))
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

        public EmployerRelation GetEmployerRelation(Guid id, bool track = false)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.EmployerRelations.SingleOrDefault(e => e.Id == id);
            }
            else
            {
                return _context.EmployerRelations.AsNoTracking().SingleOrDefault(e => e.Id == id);
            }
        }

        public EmployerRelation GetEmployerRelation(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.EmployerRelations.SingleOrDefault(e => e.Name == name);
            }
            else
            {
                return _context.EmployerRelations.AsNoTracking().SingleOrDefault(e => e.Name == name);
            }
        }

        public IQueryable<EmployerRelation> GetEmployerRelations()
        {
            return _context.EmployerRelations;
        }

        public void DeleteEmployerRelation(Guid id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetEmployerRelation(id);

            _context.EmployerRelations.Remove(entity);
            _context.SaveChanges();
        }
    }
}
