using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFProfessionalAreasRepository : IProfessionalAreasRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFProfessionalAreasRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsProfessionalArea(string code, string name)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("code", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.ProfessionalAreas.SingleOrDefault(p => p.Code == code && p.Name == name) != null;
        }

        public bool SaveProfessionalArea(ProfessionalArea entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsProfessionalArea(entity.Code, entity.Name))
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

        public ProfessionalArea GetProfessionalArea(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.ProfessionalAreas.SingleOrDefault(p => p.Id == id);
            }
            else
            {
                return _context.ProfessionalAreas.AsNoTracking().SingleOrDefault(p => p.Id == id);
            }
        }

        public ProfessionalArea GetProfessionalArea(string code, string name, bool track = false)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("code", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (track)
            {
                return _context.ProfessionalAreas.SingleOrDefault(p => p.Code == code && p.Name == name);
            }
            else
            {
                return _context.ProfessionalAreas.AsNoTracking().SingleOrDefault(p => p.Code == code && p.Name == name);
            }
        }

        public IQueryable<ProfessionalArea> GetProfessionalAreas(bool track = false)
        {
            if (track)
            {
                return _context.ProfessionalAreas;
            }
            else
            {
                return _context.ProfessionalAreas.AsNoTracking();
            }
        }

        public void DeleteProfessionalArea(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetProfessionalArea(id);

            _context.ProfessionalAreas.Remove(entity);
            _context.SaveChanges();
        }
    }
}