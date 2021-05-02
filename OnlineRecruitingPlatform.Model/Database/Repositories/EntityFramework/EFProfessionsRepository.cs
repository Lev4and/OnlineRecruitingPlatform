using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFProfessionsRepository : IProfessionsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFProfessionsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsProfession(string code, string name)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("code", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Professions.SingleOrDefault(p => p.Code == code && p.Name == name) != null;
        }

        public bool SaveProfession(Profession entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsProfession(entity.Code, entity.Name))
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

        public Profession GetProfession(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Professions.SingleOrDefault(p => p.Id == id);
            }
            else
            {
                return _context.Professions.AsNoTracking().SingleOrDefault(p => p.Id == id);
            }
        }

        public Profession GetProfession(string code, string name, bool track = false)
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
                return _context.Professions.SingleOrDefault(p => p.Code == code && p.Name == name);
            }
            else
            {
                return _context.Professions.AsNoTracking().SingleOrDefault(p => p.Code == code && p.Name == name);
            }
        }

        public IQueryable<Profession> GetProfessions(bool track = false)
        {
            if (track)
            {
                return _context.Professions;
            }
            else
            {
                return _context.Professions.AsNoTracking();
            }
        }

        public void DeleteProfession(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetProfession(id);

            _context.Professions.Remove(entity);
            _context.SaveChanges();
        }
    }
}