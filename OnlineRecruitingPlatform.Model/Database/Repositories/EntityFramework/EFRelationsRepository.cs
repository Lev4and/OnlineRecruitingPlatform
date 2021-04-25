using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFRelationsRepository : IRelationsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFRelationsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsRelation(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Relations.SingleOrDefault(c => c.Name == name) != null;
        }

        public bool SaveRelation(Relation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsRelation(entity.Name))
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

        public Relation GetRelation(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Relations.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.Relations.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public Relation GetRelation(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Relations.SingleOrDefault(c => c.Name == name);
            }
            else
            {
                return _context.Relations.AsNoTracking().SingleOrDefault(c => c.Name == name);
            }
        }

        public IQueryable<Relation> GetQueryable(bool track = false)
        {
            if (track)
            {
                return _context.Relations;
            }
            else
            {
                return _context.Relations.AsNoTracking();
            }
        }

        public void DeleteRelation(Guid id)
        {
            var entity = GetRelation(id);

            _context.Relations.Remove(entity);
            _context.SaveChanges();
        }
    }
}
