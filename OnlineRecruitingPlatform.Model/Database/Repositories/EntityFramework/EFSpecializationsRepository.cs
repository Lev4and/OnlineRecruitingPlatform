using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFSpecializationsRepository : ISpecializationsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFSpecializationsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsSpecialization(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("code", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Specializations.Include(s => s.ProfessionalArea)
                .SingleOrDefault(s => s.Code == code || s.ProfessionalArea.Code == code) != null;
        }

        public bool SaveSpecialization(Specialization entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsSpecialization(entity.Code))
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

        public Specialization GetSpecialization(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Specializations.SingleOrDefault(s => s.Id == id);
            }
            else
            {
                return _context.Specializations.AsNoTracking().SingleOrDefault(s => s.Id == id);
            }
        }

        public Specialization GetSpecialization(string code, bool track = false)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("code", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (track)
            {
                return _context.Specializations.SingleOrDefault(s => s.Code == code);
            }
            else
            {
                return _context.Specializations.AsNoTracking().SingleOrDefault(s => s.Code == code);
            }
        }

        public IQueryable<Specialization> GetSpecializations(bool track = false)
        {
            if (track)
            {
                return _context.Specializations;
            }
            else
            {
                return _context.Specializations.AsNoTracking();
            }
        }

        public void DeleteSpecialization(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetSpecialization(id);

            _context.Specializations.Remove(entity);
            _context.SaveChanges();
        }
    }
}