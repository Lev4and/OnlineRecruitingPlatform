using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacancyRelationsRepository : IVacancyRelationsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFVacancyRelationsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancyRelation(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.VacancyRelations.SingleOrDefault(v => v.Name == name) != null;
        }

        public bool SaveVacancyRelation(VacancyRelation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsVacancyRelation(entity.Name))
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

        public VacancyRelation GetVacancyRelation(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.VacancyRelations.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.VacancyRelations.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public VacancyRelation GetVacancyRelation(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (track)
            {
                return _context.VacancyRelations.SingleOrDefault(v => v.Name == name);
            }
            else
            {
                return _context.VacancyRelations.AsNoTracking().SingleOrDefault(v => v.Name == name);
            }
        }

        public IQueryable<VacancyRelation> GetVacancyRelations(bool track = false)
        {
            if (track)
            {
                return _context.VacancyRelations;
            }
            else
            {
                return _context.VacancyRelations.AsNoTracking();
            }
        }

        public void DeleteVacancyRelation(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancyRelation(id);

            _context.VacancyRelations.Remove(entity);
            _context.SaveChanges();
        }
    }
}